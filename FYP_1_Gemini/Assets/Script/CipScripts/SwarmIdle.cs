using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmIdle : SwarmBaseStates
{
    SwarmStates states;
    private float IdleTimer;
    public override void EnterState(SwarmStates states)
    {
        //Debug.Log("Enter Idle");
        states.FistCollider.enabled = false;
        states = states.GetComponent<SwarmStates>();
        states.animator.SetBool("IdleState" , true);
    }

    public override void UpdatePhysicsState(SwarmStates states)
    {
    }

    public override void UpdateState(SwarmStates states)
    {
        if (IdleTimer > states.timeswitchState)
        {
            states.SwitchStates(states.PatrolState);
            IdleTimer = 0.0f;
        }
        else if(states.weaknessDestroyed == true)
        {
            states.SwitchStates(states.DeathState);
        }
        IdleTimer += Time.deltaTime;
    }
    public override void OnCollisionEnter(SwarmStates states, Collision collision)
    {

    }
    public override void OnCollisionExit(SwarmStates states, Collision collision)
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

    public override void OnTriggerStay(SwarmStates states, Collider collider)
    {
        GameObject other = collider.gameObject;
        if (other.CompareTag("Player"))
        {
            states.SwitchStates(states.ChaseState);
        }
    }

    public override void ExitState(SwarmStates states)
    {
        states.animator.SetBool("IdleState", false);
    }
}
