using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmAttack : SwarmBaseStates 
{
    float stopAttack;
    //Declare override because we are going to define each function differently
    public override void EnterState(SwarmStates states)
    {
        Debug.Log("Attacking");
    }

    public override void UpdateState(SwarmStates states)
    {
        backToIdle(states);
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
    public void backToIdle(SwarmStates states)
    {
        if (stopAttack > states.timeswitchState)
        {
            states.SwitchStates(states.PatrolState);
            stopAttack = 0.0f;
        }
        stopAttack += Time.deltaTime;
    }
}
