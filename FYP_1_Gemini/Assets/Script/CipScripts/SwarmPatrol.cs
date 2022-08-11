using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmPatrol : SwarmBaseStates
{
    float timetoSwitch;
    float wallAvoided;
    Vector3 wanderLocation;
    public static Vector3 movementVelo;
    public static Vector3 wallsPos;

    Vector3 x = Vector3.zero;

    public override void EnterState(SwarmStates states)
    {
    }

    public override void UpdateState(SwarmStates states)
    {
        PatrollingState(states);
    }

    public override void OnCollisionEnter(SwarmStates states)
    {
    }

    public override void OnTriggerEnter(SwarmStates states, Collider collider)
    {
        GameObject other = collider.gameObject;
        if (other.CompareTag("Player"))
        {
            states.SwitchStates(states.ChaseState);
        }
        else if (other.CompareTag("Walls"))
        {
            wallsPos = other.transform.localPosition;
            states.SwitchStates(states.AvoidState);
        }
    }

    public override void OnTriggerExit(SwarmStates states, Collider collider)
    {
    }

    #region Patrolling Function
    public Vector3 RandomizeLocation(SwarmStates states)
    {
         movementVelo = Vector3.zero;

         Vector3 randomVec = Random.insideUnitSphere.normalized;
         float PatrolRadius = 10.0f;

         Vector3 currentSwarmPos = states.swarmPos;
         randomVec.y = 0.0f;

         randomVec *= PatrolRadius;

         wanderLocation = states.transform.position + (states.transform.forward.normalized) + randomVec;

        if(Vector3.Distance(states.transform.position, wanderLocation) <= 0.5)
        {
            states.SwitchStates(states.IdleState);//speed
            movementVelo = Vector3.zero;
        }
        else
        {
            movementVelo = (wanderLocation - currentSwarmPos).normalized * Random.Range(1.0f, 3.0f);//speed
        } 

         return movementVelo;
    }

    public void PatrollingState(SwarmStates states)
    {
        if (timetoSwitch > states.switchPatrolLocation) //switch after every 3 seconds
        {
            //states.SwitchStates(states.IdleState);
            x = RandomizeLocation(states);
            //Debug.Log("Switched to next pos " + x);
            timetoSwitch = 0.0f;
        }

        timetoSwitch += (Time.deltaTime);
        states.transform.Translate(x * Time.deltaTime, Space.World);
        Quaternion lookRotation = Quaternion.LookRotation(wanderLocation - states.transform.position); // GET ROTATION ANGLE
        states.transform.rotation = Quaternion.RotateTowards(states.transform.rotation, lookRotation, timetoSwitch); // ROTATE FACE NEW DIRECTION  
    }
    #endregion
}
