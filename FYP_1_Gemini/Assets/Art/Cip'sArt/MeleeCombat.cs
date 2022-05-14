using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    #region Aiming
    public Transform cameraFollow;
    [SerializeField] HumanoidLandInput input;
    [SerializeField] CameraController cameraController;
    [SerializeField] float playerLookInputLerpTime = 0.35f;
    public new Rigidbody rigidbody;
    Vector3 playerDashInput = Vector3.zero;//moving the rb in the direction of dash
    Vector3 playerAimInput = Vector3.zero;//get where the player is looking/aiming at
    public float dashSpeed;
    public float dashTime;
    public Vector3 PrevInput { get; private set; } = Vector2.zero;//where looking at previously
    float cameraPitch = 0.0f;
    [SerializeField] float rotationSpeedMultiplier = 180.0f;
    [SerializeField] float pitchSpeedMultiplier = 180.0f;
    #endregion

    public Animator charAnimation;
    private bool isAttacking;
    CombatControls inputs;

    private void Awake()
    {
        inputs = new CombatControls();

        inputs.HumanoidActions.Actions.performed += x => Attack();
        inputs.HumanoidActions.Dash.performed += x => Dash();
    }

    private void FixedUpdate()
    {
        if (!cameraController.usingOrbitalCamera)
        {
            playerAimInput = GetLookInput();
            AimedDash();
            PitchCamera();
        }
    }
    #region Dash Calculations
    private Vector3 GetLookInput()
    {
        PrevInput = playerAimInput;
        playerAimInput = new Vector3(input.LookInput.x, (input.InvertMouseY ? -input.LookInput.y : input.LookInput.y), 0.0f);
        return Vector3.Lerp(PrevInput, playerAimInput * Time.deltaTime, playerLookInputLerpTime);
    }
    private void AimedDash()
    {
        rigidbody.rotation = Quaternion.Euler(0.0f, rigidbody.rotation.eulerAngles.y + (playerAimInput.x * rotationSpeedMultiplier), 0.0f);
    }
    #endregion
    private void PitchCamera()
    {
        //Vector3 rotationValues = cameraFollow.rotation.eulerAngles;
        cameraPitch += playerAimInput.y * pitchSpeedMultiplier;
        cameraPitch = Mathf.Clamp(cameraPitch, -89.9f, 89.9f);

        cameraFollow.rotation = Quaternion.Euler(cameraPitch, cameraFollow.rotation.eulerAngles.y, cameraFollow.rotation.eulerAngles.z);
    }
    #region Enable/Disable
    private void OnEnable()
    {
        inputs.HumanoidActions.Enable();
    }

    private void OnDisable()
    {
        inputs.HumanoidActions.Disable();
    }
    #endregion

    // Update is called once per frame
    public void Attack()
    {
        #region BasicAttack
        StartAttack();
        var attack = Random.Range(1,3);

        charAnimation.SetTrigger("Attack"+attack);
         #endregion
    }

    public void Dash()
    {
        #region Dodging
        StartCoroutine(dashCoroutine());
        charAnimation.SetTrigger("Dash");
        #endregion
    }

    public void StartAttack()
    {
        isAttacking = true;
    }

    public void StopAttack()
    {
        isAttacking = false;
    }

    IEnumerator dashCoroutine()
    {
        float startTime = Time.time;
        while(Time.time < startTime + dashTime)
        {
            //Debug.Log("Coroutine Called");
            playerDashInput = new Vector3(transform.position.x * dashSpeed * rigidbody.mass,
                transform.position.y * rigidbody.mass,
                transform.position.z * dashSpeed * rigidbody.mass);

            Debug.Log(playerDashInput);
            rigidbody.AddRelativeForce(playerDashInput, ForceMode.Force);
            yield return null;
        }
    }
}
