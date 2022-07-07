using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmAvoidObstacles : SwarmBaseStates
{
    Vector3 wallPosition;
    float timeInState;
    public override void EnterState(SwarmStates states)
    {
        Debug.Log("Hello from avoiding");
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

    #region Avoiding Walls
    public void AvoidWalls(SwarmStates states)
    {
        if(timeInState > 2.0f)
        {
            states.SwitchStates(states.PatrolState);
            timeInState = 0.0f;
        }
        timeInState += Time.deltaTime;
        Debug.Log("Wall coordinates: " + SwarmPatrol.wallsPos);

        Vector3 movement = (SwarmPatrol.wallsPos - SwarmPatrol.movementVelo).normalized * -1;
        Vector3 runVelocity = movement * 5.0f;
        states.transform.Translate(runVelocity * Time.deltaTime, Space.World);
    }
    #endregion
}
