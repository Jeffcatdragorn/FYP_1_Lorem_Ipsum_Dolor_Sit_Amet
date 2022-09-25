using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankPatrolStateJane : TankAbstractJane
{
    float timer;
    int patrolPointIndex;
    float distanceToPatrolPoint;
    NavMeshAgent navMeshAgent;

    public override void EnterState(TankManagerJane Tank)
    {
        timer = 0;

        Tank.transform.LookAt(Tank.patrolPoints[patrolPointIndex].position);
        navMeshAgent = Tank.GetComponent<NavMeshAgent>();
    }

    public override void ExitState(TankManagerJane Tank)
    {
        NavMeshStopPatrolling(Tank);
    }

    public override void OnCollisionEnter(TankManagerJane Tank, Collision collider)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(TankManagerJane Tank, Collider collider)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(TankManagerJane Tank, Collider collider)
    {
        if (collider.tag == "Player") //vision collider + tank body collider
        {
            Tank.SwitchState(Tank.attack);
        }
    }

    public override void UpdateState(TankManagerJane Tank)
    {
        if (Tank.isAlive)
        {
            PatrolBehaviour(Tank);
        }
    }

    public void PatrolBehaviour(TankManagerJane Tank)
    {
        timer += Time.deltaTime;

        if (timer > Tank.patrolTime) //stop patrolling
        {
            NavMeshStopPatrolling(Tank); //stop patrolling first b4 switching state
            Tank.SwitchState(Tank.idle);
        }
        else //still patrolling
        {
            Patrol(Tank);
        }
    }

    void Patrol(TankManagerJane Tank)
    {
        distanceToPatrolPoint = Vector3.Distance(Tank.transform.position, Tank.patrolPoints[patrolPointIndex].transform.position);

        if(distanceToPatrolPoint < 1f) //reached patrol point
        {
            IncreasePatrolPointIndex(Tank);
        }
        else
        {
            NavMeshPatrolling(Tank);
        }
    }

    void IncreasePatrolPointIndex(TankManagerJane Tank)
    {
        patrolPointIndex++;

        if(patrolPointIndex >= Tank.patrolPoints.Length)
        {
            patrolPointIndex = 0;
        }

        NavMeshPatrolling(Tank);
    }

    void NavMeshPatrolling(TankManagerJane Tank)
    {
        navMeshAgent.destination = Tank.patrolPoints[patrolPointIndex].position;
    }

    void NavMeshStopPatrolling(TankManagerJane Tank)
    {
        navMeshAgent.SetDestination(Tank.transform.position);
    }
}
