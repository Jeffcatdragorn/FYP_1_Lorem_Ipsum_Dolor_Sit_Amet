using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmChase : SwarmBaseStates
{
    float DistancetoPlayer = 0.0f;
    float timeInState = 0.0f;
    bool chasePlayer = false;
    Vector3 PlayerPos;
    Vector3 SwarmToPlayer = Vector3.zero;
    //float chasingSpeed;
    public override void EnterState(SwarmStates states)
    {
        Debug.Log("Swarm Chase");
        PlayerPos = states.playerPos;
    }

    public override void UpdatePhysicsState(SwarmStates states)
    {
        if(chasePlayer == true)
            states.rb.AddForce(ChaseFormula(states) * 60.0f, ForceMode.Impulse);
    }

    public override void UpdateState(SwarmStates states)
    {
        FaceDirection(states);
    }

    public override void OnCollisionEnter(SwarmStates states)
    {
    }
    public override void OnTriggerEnter(SwarmStates states, Collider collider)
    {
    }

    public override void OnTriggerExit(SwarmStates states, Collider collider)
    {
        states.SwitchStates(states.PatrolState);
    }

    public override void OnTriggerStay(SwarmStates states, Collider collider)
    {
        if(collider.tag == "Player")
        {
            chasePlayer = true;
        }
    }
    public Vector3 ChaseFormula(SwarmStates states)
    {
        SwarmToPlayer = (PlayerPos - states.swarmPos).normalized;
        //DistancetoPlayer = Vector3.Distance(PlayerPos, states.swarmPos) - 1;

        Vector3 chaseVelo = SwarmToPlayer;

        chaseVelo.y = 0.0f;

        return chaseVelo;
    }

    public void FaceDirection(SwarmStates states)
    {
        Quaternion lookRotation = Quaternion.LookRotation(ChaseFormula(states).normalized); // GET ROTATION ANGLE
        lookRotation.x = lookRotation.z = 0.0f;
        states.transform.rotation = Quaternion.Slerp(states.transform.rotation, lookRotation, Time.deltaTime * 1.0f); // ROTATE FACE NEW DIRECTION
    }
}
