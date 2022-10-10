using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmAvoidObstacles : SwarmBaseStates
{
    Vector3 wallPosition;
    float timeInState;
    public override void EnterState(SwarmStates states)
    {
    }

    public override void UpdateState(SwarmStates states)
    {
        AvoidWalls(states);
    }

    public override void OnCollisionEnter(SwarmStates states)
    {
    }

    public override void OnTriggerEnter(SwarmStates states, Collider collider)
    {
    }

    public override void OnTriggerExit(SwarmStates states, Collider collider)
    {
    }

    public override void OnTriggerStay(SwarmStates states, Collider collider)
    {
    }
    #region Avoiding Walls
    public void AvoidWalls(SwarmStates states)
    {
        if(timeInState > 2.0f)
        {
            states.SwitchStates(states.PatrolState);
            timeInState = 0.0f;
        }
        timeInState += Time.deltaTime;


        Vector3 movement = (SwarmPatrol.wallsPos - SwarmPatrol.movementVelo).normalized * -1;
        movement.y = 0.0f;
        Vector3 runVelocity = movement * 5.0f;
        Quaternion lookRotation = Quaternion.LookRotation(movement - states.swarmPos); // GET ROTATION ANGLE
        states.transform.rotation = Quaternion.Slerp(states.transform.rotation, lookRotation, Time.deltaTime * 4.0f); // ROTATE FACE NEW DIRECTION
        states.transform.Translate(runVelocity * Time.deltaTime, Space.World);
    }
    #endregion
}
