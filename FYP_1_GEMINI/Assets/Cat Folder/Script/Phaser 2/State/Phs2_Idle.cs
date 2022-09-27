using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phs2_Idle : Phsr2_Abstract
{
    float timer;
    Animator animator;
    public override void EnterState(Phaser2_Manager Phsr)
    {
        Debug.Log("idling");
    }
    
    public override void UpdateState(Phaser2_Manager phsr)
    {
        //Debug.Log("idling");
        if (phsr.Alive)
        {
            Idling(phsr);
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
        if (col.tag == "Player")
        {
            phsr.SwitchState(phsr.Attack);
        }
    }

    public override void ExitState(Phaser2_Manager phsr)
    {
    }
    public void Idling(Phaser2_Manager phsr)
    {
        timer += Time.deltaTime;
        if (timer > phsr.IdleCd)
        {
            phsr.SwitchState(phsr.Attack);
        }
    }
}
