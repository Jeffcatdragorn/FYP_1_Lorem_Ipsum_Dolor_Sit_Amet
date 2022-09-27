using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phs2_Attack : Phsr2_Abstract
{
    int num; // temp
    Animator anim;

    public override void EnterState(Phaser2_Manager Phsr)
    {
        Debug.Log("attack");
        anim = Phsr.GetComponent<Animator>();
        anim.SetTrigger("attack");
    }

    public override void UpdateState(Phaser2_Manager phsr)
    {
        if (num == 0)
        {
            Phase1(phsr);
            num++;
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
            anim.SetTrigger("attack");
        }
    }
    public void Phase2(Phaser2_Manager phsr)
    {
        if (phsr.AliveP2)
        {

        }
    }
}
