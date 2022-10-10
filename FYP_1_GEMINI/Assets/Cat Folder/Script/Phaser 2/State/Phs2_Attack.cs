using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phs2_Attack : Phsr2_Abstract
{
    int num; // temp
    float timer;
    Animator anim;
    bool doneAttack;

    public override void EnterState(Phaser2_Manager Phsr)
    {
        //Debug.Log("attack");
        anim = Phsr.GetComponent<Animator>();
        //anim.SetTrigger("attack");
        timer = 0;
        doneAttack = false;
    }

    public override void UpdateState(Phaser2_Manager phsr)
    {
        if (phsr.Alive)
        {
            phsr.transform.LookAt(phsr.player.transform.position);
            timer += Time.deltaTime;
            Phase1(phsr);
            Phase2(phsr);
        }
    }
    #region colliders and triggers
    public override void OnCollisionEnter(Phaser2_Manager phsr, Collision col)
    {
    }

    public override void OnTriggerEnter(Phaser2_Manager phsr, Collider col)
    {
    }

    public override void OnTriggerStay(Phaser2_Manager phsr, Collider col)
    {
    }
    #endregion
    public override void ExitState(Phaser2_Manager phsr)
    {
    }

    public void Phase1(Phaser2_Manager phsr)
    {
        if (phsr.AliveP1)
        {
            if (!doneAttack)
            {
                anim.SetTrigger("attack");
                doneAttack = true;
            }
            if (phsr.test1)
            {
                if (timer > 3) // 3 is the cd before it starts moving again
                {

                    phsr.SwitchState(phsr.Move);
                }
            }
            if (phsr.test2)
            {
                if (doneAttack)
                {
                    phsr.SwitchState(phsr.Move);
                }
            }

        }
    }
    public void Phase2(Phaser2_Manager phsr)
    {
        if (phsr.AliveP2)
        {
            if (!doneAttack)
            {
                anim.SetTrigger("attack");
                phsr.CreateMultiLightningBall(20, 10);
                doneAttack = true;
            }
            if (phsr.test1)
            {
                if (timer > 3) // 3 is the cd before it starts moving again
                {
                    phsr.SwitchState(phsr.Move);
                }
            }
            if (phsr.test2)
            {
                if (doneAttack)
                {
                    phsr.SwitchState(phsr.Move);
                }
            }
            if (timer > 2) phsr.SwitchState(phsr.Move);
        }
    }

    
}
