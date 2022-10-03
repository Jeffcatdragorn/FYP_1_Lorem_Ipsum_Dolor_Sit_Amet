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
            timer += Time.deltaTime;
            Phase1(phsr);
            Phase2(phsr);
        }
    }

    public override void OnCollisionEnter(Phaser2_Manager phsr, Collision col)
    {
    }

    public override void OnTriggerEnter(Phaser2_Manager phsr, Collider col)
    {
    }

    public override void OnTriggerStay(Phaser2_Manager phsr, Collider col)
    {
    }

    public override void ExitState(Phaser2_Manager phsr)
    {
    }

    public void Phase1(Phaser2_Manager phsr)
    {
        if (phsr.AliveP1)
        {
            if (doneAttack == false)
            {
                anim.SetTrigger("attack");
                doneAttack = true;
            }
            if (phsr.test1)
            {
                if (timer > 3) 
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
            Debug.Log("im here dy");
            if (timer > 2) phsr.SwitchState(phsr.Move);
        }
    }
}
