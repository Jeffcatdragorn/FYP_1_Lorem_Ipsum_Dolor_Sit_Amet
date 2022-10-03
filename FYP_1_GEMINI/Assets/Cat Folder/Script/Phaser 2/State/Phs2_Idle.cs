using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phs2_Idle : Phsr2_Abstract
{
    Animator animator;
    float distance;
    public override void EnterState(Phaser2_Manager Phsr)
    {
        //Debug.Log("idling");
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
    }

    public override void ExitState(Phaser2_Manager phsr)
    {
    }
    public void Idling(Phaser2_Manager phsr)
    {
        distance = Vector3.Distance(phsr.player.transform.position, phsr.transform.position);
        //Debug.Log(distance);
        if (distance < phsr.playerRange)
        {
            phsr.SwitchState(phsr.Attack);
        }
    }
}
