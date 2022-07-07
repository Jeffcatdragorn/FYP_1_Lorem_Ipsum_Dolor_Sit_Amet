using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmIdle : SwarmBaseStates
{
    SwarmStates states;
    public override void EnterState(SwarmStates states)
    {
        states = states.GetComponent<SwarmStates>();
    }

    public override void UpdateState(SwarmStates states)
    {
        if(states.testingStates == true)
        {
            states.SwitchStates(states.PatrolState);
        }
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
}
