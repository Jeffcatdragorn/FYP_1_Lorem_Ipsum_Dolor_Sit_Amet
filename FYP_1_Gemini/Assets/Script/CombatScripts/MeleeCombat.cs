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

        inputs.HumanoidActions.Punching.performed += x => Attack();
        inputs.HumanoidActions.Dashing.performed += x => Dash();
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

    public void Attack()
    {
        #region BasicAttack
        if (!isAttacking)
        {
            StartAttack();
            charAnimation.SetTrigger("Attack1");
        }
        #endregion
    }

    public void Dash()
    {
        #region Dashing
        charAnimation.SetTrigger("Dash");
        #endregion
    }

    #region Setters
    public void StartAttack()
    {
        isAttacking = true;
    }

    public void StopAttack()
    {
        isAttacking = false;
    }
    #endregion
}
