using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Phs_Attack : Phsr_Abstract
{
    float timer;
    float rate;
    Animator anim;
    float distance;
    GameObject player;
    NavMeshAgent navmeshAgent;
    public override void EnterState(Phaser_Manager Phsr)
    {
        anim = Phsr.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        navmeshAgent = Phsr.GetComponent<NavMeshAgent>();
        
        anim.SetTrigger("attack");
        navmeshAgent.ResetPath();
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
        if (phsr.Alive)
        {
            Attack(phsr);
        }
    }

    void Attack(Phaser_Manager phsr)
    {
        if (timer < phsr.AttackCd)
        {
            if (distance < phsr.AttackRange)
            {
                navmeshAgent.SetDestination(player.transform.position);
                timer = 0;
            }
            if (distance < 2)
            {
                phsr.SwitchState(phsr.Melee);
            }
        }
        else
        {
            phsr.SwitchState(phsr.Idle);
        }
        //timer += Time.deltaTime;
        //rate += Time.deltaTime;
        //phsr.transform.LookAt(player.transform.position);
        //distance = Vector3.Distance(player.transform.position, phsr.transform.position);
        //if (timer < phsr.AttackCd)
        //{
        //    if (distance < phsr.AttackRange)
        //    {
        //        Debug.Log("dis- " + distance + "range- " + phsr.AttackRange);
        //        if (rate > phsr.AttackRate)
        //        {
        //            anim.SetTrigger("attack");
        //            timer = 0;
        //            rate = 0;
        //        }
        //    }
        //    else
        //    {

        //    }
        //}
        //else
        //{
        //    phsr.SwitchState(phsr.Idle);
        //}

        //if (distance < phsr.AttackRange)
        //{
        //    Debug.Log("dis- " + distance + "range- " + phsr.AttackRange);
        //    navmeshAgent.SetDestination(player.transform.position);
        //    anim.SetBool("walk", true);
        //    bool tempTriggerChecker;
            //tempTriggerChecker = anim.GetBool("attack");
            //if (tempTriggerChecker == true)
            //{
            //    navmeshAgent.ResetPath();
            //    navmeshAgent.SetDestination(phsr.transform.position);
            //}
            //else
            //{
            //    navmeshAgent.SetDestination(player.transform.position);
            //}

            //if (distance < 2)
            //{
            //    navmeshAgent.ResetPath();
            //    navmeshAgent.SetDestination(phsr.transform.position);
            //    if (rate > phsr.AttackRate)
            //    {
            //        anim.SetBool("walk", false);
            //        anim.SetTrigger("attack");
            //        timer = 0;
            //        rate = 0;
            //    }
            //}
        //}
    }
}
