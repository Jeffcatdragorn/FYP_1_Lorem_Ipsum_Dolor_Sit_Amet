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
        Debug.Log("Patrolling");
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
            Debug.Log(wallsPos);
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
         float PatrolRadius = 4.0f;

         Vector3 currentSwarmPos = states.swarmPos;
         randomVec.y = 0.0f;

         randomVec *= PatrolRadius;

         wanderLocation = states.transform.position + (states.transform.forward.normalized) + randomVec;
         movementVelo = (wanderLocation - currentSwarmPos).normalized * Random.Range(1.0f,5.0f);

         return movementVelo;
    }

    public void PatrollingState(SwarmStates states)
    {
        if (timetoSwitch > states.switchPatrolLocation) //switch after every 3 seconds
        {
            Debug.Log("Switched");
            x = RandomizeLocation(states);
            timetoSwitch = 0.0f;
        }

        timetoSwitch += Time.deltaTime;
        Quaternion lookRotation = Quaternion.LookRotation(wanderLocation - states.swarmPos); // GET ROTATION ANGLE
        states.transform.rotation = Quaternion.Slerp(states.transform.rotation, lookRotation, Time.deltaTime * 4.0f); // ROTATE FACE NEW DIRECTION
        states.transform.Translate(x * Time.deltaTime, Space.World);
    }
    #endregion
}
