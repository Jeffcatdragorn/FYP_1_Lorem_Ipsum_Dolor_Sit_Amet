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
        Debug.Log("Attacking");
    }
    public override void UpdatePhysicsState(SwarmStates states)
    {
    }
    public override void UpdateState(SwarmStates states)
    {
        attackPlayer(states);
    }

    public override void OnCollisionEnter(SwarmStates states)
    {

    }

    public override void OnTriggerEnter(SwarmStates states, Collider collider)
    {
    }
    public override void OnTriggerExit(SwarmStates states, Collider collider)
    {
        GameObject other = collider.gameObject;
        if (other.tag == "playerSelf")
        {
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
            AttackRate = 0.0f;
        }
        AttackRate += Time.deltaTime;
    }
}
