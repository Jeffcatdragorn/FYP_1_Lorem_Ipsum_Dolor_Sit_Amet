using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmAttack : SwarmBaseStates 
{
    float stopAttack;
    float AttackRate;

    //Declare override because we are going to define each function differently
    public override void EnterState(SwarmStates states)
    {
        //Debug.Log("Enter Attacking");
        states.animator.SetBool("AttackState", true);
    }
    public override void UpdatePhysicsState(SwarmStates states)
    {
    }
    public override void UpdateState(SwarmStates states)
    {
        if (states.weaknessDestroyed != true)
        {
            attackPlayer(states);
        }
        else
            states.SwitchStates(states.DeathState);
        
    }

    public override void OnCollisionEnter(SwarmStates states, Collision collision)
    {

    }

    public override void OnTriggerEnter(SwarmStates states, Collider collider)
    {
    }
    public override void OnTriggerExit(SwarmStates states, Collider collider)
    {
        GameObject other = collider.gameObject;
        if (other.tag == "Player")
        {
            Debug.Log("Player Exited");
            states.SwitchStates(states.ChaseState);
        }
    }

    public override void OnTriggerStay(SwarmStates states, Collider collider)
    {
    }
    public void attackPlayer(SwarmStates states)
    {
        if (AttackRate > 3.0f)
        {
            Debug.Log("Attacking");
            states.animator.Play("AnimAttack");
            AttackRate = 0.0f;
        }
        AttackRate += Time.deltaTime;
    }

    public override void ExitState(SwarmStates states)
    {
        states.animator.SetBool("AttackState", false); 
    }
}
