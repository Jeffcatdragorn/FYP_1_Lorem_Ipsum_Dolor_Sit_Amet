using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmAvoidObstacles : SwarmBaseStates
{
    Vector3 wallPosition;
    float timeInState;
    public override void EnterState(SwarmStates states)
    {
        Debug.Log("Avoid Walls State");
    }
    
    public override void UpdatePhysicsState(SwarmStates states)
    {
        //AvoidWalls(states);
    }

    public override void UpdateState(SwarmStates states)
    {
       TimeInState(states);
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
    /*public void AvoidWalls(SwarmStates states)
    {
        Vector3 movement = (states.swarmPos - SwarmPatrol.wallsPos) * -1;
        movement.y = 0.0f;
        Vector3 runVelocity = movement;
        Quaternion lookRotation = Quaternion.LookRotation(movement - states.swarmPos); // GET ROTATION ANGLE
        states.transform.rotation = Quaternion.Slerp(states.transform.rotation, lookRotation, Time.deltaTime * 4.0f); // ROTATE FACE NEW DIRECTION
        states.rb.AddForce((movement * 100.0f), ForceMode.Impulse);
        //states.transform.Translate(runVelocity * Time.deltaTime, Space.World);
    }*/
    

    //Exit State timer. Put under update state.
    public void TimeInState(SwarmStates states)
    {
        if(timeInState > 10.0f)
        {
            states.SwitchStates(states.PatrolState);
            timeInState = 0.0f;
        }
        timeInState += Time.deltaTime;
    }
    #endregion
}
