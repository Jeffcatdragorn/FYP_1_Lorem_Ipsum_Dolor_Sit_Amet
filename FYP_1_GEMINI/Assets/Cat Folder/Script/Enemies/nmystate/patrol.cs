using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : Enemies_Abstract
{
    float patrolTimer = .0f;
    Animator anim;
    public override void EnterState(Enemies_Manager enemy)
    {
        //Debug.Log("Entered Patrol State");
        anim = enemy.GetComponent<Animator>();
        anim.SetBool("walk", true);
        enemy.Patrolling();
    }

    public override void UpdateState(Enemies_Manager enemy)
    {
        if (enemy.health > 0)
        {
            Patrol(enemy);
        }
    }

    public override void OnCollisionEnter(Enemies_Manager enemy, Collision collision)
    {
    }

    public override void ExitState(Enemies_Manager enemy)
    {
        enemy.StopPatrolling();
        anim.SetBool("walk", false);

        //Debug.Log("exit patrol state");

    }
    public void Patrol(Enemies_Manager enemy)
    {
        patrolTimer += Time.deltaTime;
        if (patrolTimer > enemy.PatrolTime)
        {
            patrolTimer = .0f;
            enemy.StopPatrolling();
            enemy.SwitchState(enemy.IdleState);
        }
        else if (enemy.DistToPoint < 1f && patrolTimer < 5.0f)
        {
            enemy.IncreaseIndex();
            enemy.Patrolling();
        }

        if (enemy.stillNeedTeleport)
        {
            enemy.SwitchState(enemy.TeleportState);
        }

        if (enemy.attack)
        {
            enemy.SwitchState(enemy.AttackState);
        }
    }
}
