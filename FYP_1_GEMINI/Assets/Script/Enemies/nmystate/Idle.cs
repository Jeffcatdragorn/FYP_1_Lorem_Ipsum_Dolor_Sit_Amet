using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Enemies_Abstract
{
    float idleTimer = .0f;
    
    public override void EnterState(Enemies_Manager enemy)
    {
        //Debug.Log("Entered Idle State");

        Animator anim = enemy.GetComponent<Animator>();
        anim.SetBool("walk", false);
        
    }

    public override void UpdateState(Enemies_Manager enemy)
    {
        idleTimer += Time.deltaTime;
        if (idleTimer > enemy.IdleTime)
        {
            idleTimer = 0;
            enemy.SwitchState(enemy.PatrolState);
        }

        if (enemy.teleport_B)
        {
            enemy.SwitchState(enemy.TeleportState);
        }
    }

    public override void OnCollisionEnter(Enemies_Manager enemy, Collision collision)
    {
    }

    public override void ExitState(Enemies_Manager enemy)
    {
    }
}
