using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public Animator charAnimation;
    private bool isAttacking;

    // Update is called once per frame
    void Update()
    {
        #region BasicAttack
        if (Input.GetKey("E"))
        {
            if (!isAttacking)
            {
                StartAttack();
                charAnimation.SetTrigger("Attack1");
            }
        }
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
