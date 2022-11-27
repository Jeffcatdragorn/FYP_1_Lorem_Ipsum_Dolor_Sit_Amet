using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmDeath : SwarmBaseStates
{
    SwarmStates swarmStates;

    public override void EnterState(SwarmStates states)
    {
        swarmStates = states.GetComponent<SwarmStates>();
        states.animator.SetBool("DeathState", true);

        Debug.Log("Im death");
    }

    public override void UpdatePhysicsState(SwarmStates states)
    {
       
    }

    public override void UpdateState(SwarmStates states)
    {
        states.GetComponent<CapsuleCollider>().enabled = false;
    }

    public override void OnCollisionEnter(SwarmStates states, Collision collision)
    {
       
    }
    public override void OnCollisionExit(SwarmStates states, Collision collision)
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

    public override void ExitState(SwarmStates states)
    {
        
    }
}
