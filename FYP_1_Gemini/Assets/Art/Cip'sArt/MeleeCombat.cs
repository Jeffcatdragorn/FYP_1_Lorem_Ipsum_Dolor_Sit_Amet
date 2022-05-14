using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public Animator charAnimation;
    private bool isAttacking;

    public Vector3 LookInput { get; private set; } = Vector2.zero;

    CombatControls inputs;

    private void Awake()
    {
        inputs = new CombatControls();

        inputs.HumanoidActions.Actions.performed += x => Attack();
        inputs.HumanoidActions.Dash.performed += x => Evade();
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

    public void Evade()
    {
        #region Dodging
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
}
