using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : Enemies_Abstract
{
    float attackRateTimer = .0f;
    float attackTimer = .0f;
    Animator anim;
    public override void EnterState(Enemies_Manager enemy)
    {
        Debug.Log("attack");

        anim = enemy.GetComponent<Animator>();
        anim.SetBool("attack", true);
    }

    public override void UpdateState(Enemies_Manager enemy)
    {
        if (enemy.health > 0)
        {
            Attack(enemy);
        }
    }

    public override void OnCollisionEnter(Enemies_Manager enemy, Collision collision)
    {
    }

    public override void ExitState(Enemies_Manager enemy)
    {
        Debug.Log("done attack");

    }
    public void Attack(Enemies_Manager enemy)
    {
        attackRateTimer += Time.deltaTime;
        //Debug.Log(enemy.DistToPlayer + " = Player");
        if (attackRateTimer > enemy.attackRate)
        {
            if (enemy.DistToPlayer < enemy.attackRange)
            {
                Debug.Log("attack again");
                GameObject player = GameObject.FindWithTag("Player");
                enemy.transform.LookAt(player.transform);
                anim.SetBool("attack", true);
                attackRateTimer = .0f;
            }
        }

        attackTimer += Time.deltaTime;
        if (attackTimer > enemy.attackTime)
        {
            enemy.SwitchState(enemy.IdleState);
            enemy.attack = false;
        }
    }
}
