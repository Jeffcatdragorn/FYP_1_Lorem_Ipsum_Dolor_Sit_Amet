using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmAttack : SwarmBaseStates 
{
    float stopAttack;
    float AttackRate;
    private GameObject other;


    //Declare override because we are going to define each function differently
    public override void EnterState(SwarmStates states)
    {
        Debug.Log("Enter Attacking");
        //attackPlayer(states);
        states.animator.SetBool("AttackState", true);
        states.FistCollider.enabled = true;
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




        if (Vector3.Distance(other.transform.position, states.swarmPos) > 10)
        {
            Debug.Log("Player Exited");
            states.SwitchStates(states.ChaseState);
        }

    }

    public override void OnCollisionEnter(SwarmStates states, Collision collision)
    {

    }
    public override void OnCollisionExit(SwarmStates states, Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            other = collision.gameObject;
        }

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
    public void attackPlayer(SwarmStates states)
    {
        if (AttackRate > 3.0f)
        {
            Debug.Log("Attacking");
            states.FistCollider.enabled = true;
            states.animator.Play("AnimAttack");
            AttackRate = 0.0f;
        }
        AttackRate += Time.deltaTime;
    }

    public override void ExitState(SwarmStates states)
    {
        states.animator.SetBool("AttackState", false); 
        states.FistCollider.enabled = false;
    }
}
