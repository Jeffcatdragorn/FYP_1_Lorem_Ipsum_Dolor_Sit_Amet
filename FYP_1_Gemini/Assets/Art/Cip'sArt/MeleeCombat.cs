using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    #region Dashing
    [SerializeField] HumanoidLandInput input;
    public new Rigidbody rigidbody;
    public float dashSpeed;
    public float dashDuration;
    #endregion

    public Animator charAnimation;
    private bool isAttacking;
    private bool isDashing;
    CombatControls combatInput;

    #region ComboWindow
    [SerializeField]
    bool windowActive = false;
    private float comboWindow;
    private float defaultComboWindow = 1;
    #endregion

    private void Awake()
    {
        combatInput = new CombatControls();
        comboWindow = defaultComboWindow;
        combatInput.HumanoidActions.Actions.performed += x => Attack();
        //combatInput.HumanoidActions.Dash.performed += x => Dash(); //x is a var so to speak/reference point?
    }

    private void Update()
    {
        combatInput.HumanoidActions.Dash.performed += x => Dash();
        if (windowActive == true)
        {
            ComboAttack();
        }
    }

    #region Enable/Disable
    private void OnEnable()
    {
        combatInput.HumanoidActions.Enable();
    }

    private void OnDisable()
    {
        combatInput.HumanoidActions.Disable();
    }
    #endregion

    public void Attack()
    {
        #region BasicAttack
        StartAttack();
        if (windowActive == false)
        {
            var attack = Random.Range(1, 3);
            charAnimation.SetTrigger("Attack" + attack);
        }
        #endregion
    }

    public void Dash()
    {
        #region Dodging
        StartCoroutine(dashCoroutine());

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

    public void ComboAttack()
    {
        if (combatInput.HumanoidActions.Actions.triggered)
        {
            Debug.LogError("Input working fine");
            charAnimation.SetTrigger("SuperAttack");
            //charAnimation.applyRootMotion = true; //to trigger root motion
            windowActive = false;
        }
    }

    IEnumerator dashCoroutine()
    {
        float startTime = Time.time;
        float dashTime = startTime + dashDuration;
        Debug.LogWarning(dashTime);
        while (Time.time < dashTime)
        {
            rigidbody.AddRelativeForce(new Vector3(0,0,input.LookInput.x +  dashSpeed), ForceMode.Impulse);
            charAnimation.SetTrigger("Dash");
            yield return null;
        }
        windowActive = true;
    }
}
