using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    #region Dashing
    [SerializeField] HumanoidLandInput input;
    public new Rigidbody rigidbody;
    public float dashSpeed;
    public float dashTime;
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
            rigidbody.AddRelativeForce(new Vector3(0,0,input.LookInput.x +  dashSpeed), ForceMode.Impulse);
            yield return null;
        }
    }
}
