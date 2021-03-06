using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmIdle : SwarmBaseStates
{
    SwarmStates states;
    private float IdleTimer;
    public override void EnterState(SwarmStates states)
    {
        states = states.GetComponent<SwarmStates>();
    }

    public override void UpdateState(SwarmStates states)
    {
        if (IdleTimer > states.timeswitchState)
        {
            states.SwitchStates(states.PatrolState);
            IdleTimer = 0.0f;
        }
        IdleTimer += Time.deltaTime;
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
    }
    public override void OnTriggerExit(SwarmStates states, Collider collider)
    {
    }
}
