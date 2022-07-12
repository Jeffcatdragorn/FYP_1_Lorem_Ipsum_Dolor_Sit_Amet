using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Phs_Patrol : Phsr_Abstract
{
    float timer;
    Animator anim;
    int waypointIndex;
    float distToPoint;
    private NavMeshAgent navMeshAgent;

    public override void EnterState(Phaser_Manager Phsr)
    {
        //Debug.Log("Patrol");
        anim = Phsr.gameObject.GetComponent<Animator>();
        anim.SetBool("walk", true);
        timer = 0;

        Phsr.transform.LookAt(Phsr.waypoint[waypointIndex].position);
        navMeshAgent = Phsr.GetComponent<NavMeshAgent>();
    }
    public override void ExitState(Phaser_Manager phsr)
    {
        //Debug.Log("Patrol Exit");
        StopPatrolling(phsr);
    }
    #region collision and trigger stuff
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
            phsr.SwitchState(phsr.Teleport);
        }
    }
    #endregion

    public override void UpdateState(Phaser_Manager phsr)
    {
        if (phsr.Alive)
        {
            Patrol(phsr);
        }
    }
    void Patrol(Phaser_Manager phsr)
    {
        timer += Time.deltaTime;
        if (timer < phsr.PatrolCd) // still patrol
        {
            CatsPatrol(phsr);
        }
        else // finish patrol
        {
            StopPatrolling(phsr);
            phsr.SwitchState(phsr.Idle);
        }
    }
    void CatsPatrol(Phaser_Manager phsr)
    {
        distToPoint = Vector3.Distance(phsr.transform.position, phsr.waypoint[waypointIndex].transform.position);
        if (distToPoint < 1f)
        {
            IncreaseIndex(phsr);
            //Debug.Log("reached");
        }
        else
        {
            //Debug.Log("still walking");
            Patrolling(phsr);
        }
    }

    void IncreaseIndex(Phaser_Manager phsr)
    {
        waypointIndex++;
        if (waypointIndex >= phsr.waypoint.Length)
        {
            waypointIndex = 0;
        }
        Patrolling(phsr);
    }
    public void Patrolling(Phaser_Manager phsr)
    {
        navMeshAgent.destination = phsr.waypoint[waypointIndex].position;
        anim.SetBool("walk", true);
    }
    public void StopPatrolling(Phaser_Manager phsr)
    {
        navMeshAgent.SetDestination(phsr.transform.position);
        anim.SetBool("walk", false);
    }
}
