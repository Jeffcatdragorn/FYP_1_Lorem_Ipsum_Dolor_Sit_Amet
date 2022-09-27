using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phs_idle : Phsr_Abstract
{
    float timer;
    Animator anim;
    public override void EnterState(Phaser_Manager Phsr)
    {
        //Debug.Log("idle");
        anim = Phsr.gameObject.GetComponent<Animator>();
        timer = 0;
    }

    public override void ExitState(Phaser_Manager phsr)
    {
        //Debug.Log("idle Exit");
    }
    #region collider and trigger stuff
    public override void OnCollisionEnter(Phaser_Manager phsr, Collision col)
    {
    }

    public override void OnTriggerEnter(Phaser_Manager phsr, Collider col)
    {
    }

    public override void OnTriggerStay(Phaser_Manager phsr, Collider col)
    {
        if (col.tag == "Player")
        {
            phsr.SwitchState(phsr.Attack);
        }
    }
    #endregion
    public override void UpdateState(Phaser_Manager phsr)
    {
        //Debug.Log("idling");
        if (phsr.Alive)
        {
            Idling(phsr);
        }
    }

    public void Idling(Phaser_Manager phsr)
    {
        timer += Time.deltaTime;
        if (timer > phsr.IdleCd)
        {
            phsr.SwitchState(phsr.Patrol);
        }
    }
}
        //throw new System.NotImplementedException();
