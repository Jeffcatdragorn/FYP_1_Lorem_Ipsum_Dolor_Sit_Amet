using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phs_Melee : Phsr_Abstract
{
    Animator anim;
    float rate;
    float timer;
    public override void EnterState(Phaser_Manager Phsr)
    {
        anim = Phsr.GetComponent<Animator>();
    }

    public override void ExitState(Phaser_Manager phsr)
    {
    }

    public override void OnCollisionEnter(Phaser_Manager phsr, Collision col)
    {
    }

    public override void OnTriggerEnter(Phaser_Manager phsr, Collider col)
    {
    }

    public override void OnTriggerStay(Phaser_Manager phsr, Collider col)
    {
    }

    public override void UpdateState(Phaser_Manager phsr)
    {
        Melee(phsr);
    }

    void Melee(Phaser_Manager phsr)
    {
        if (timer < phsr.MeleeCd)
        {
            if (rate > phsr.MeleeRate)
            {
                anim.SetBool("attack", true);
                rate = 0;
            }
        }
        else
        {
            phsr.SwitchState(phsr.Attack);
        }
    }
}
