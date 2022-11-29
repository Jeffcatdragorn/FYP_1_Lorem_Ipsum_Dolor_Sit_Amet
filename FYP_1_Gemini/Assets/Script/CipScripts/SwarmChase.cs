using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmChase : SwarmBaseStates
{
    //float DistancetoPlayer = 0.0f;
    //float timeInState = 0.0f;
    //bool chasePlayer = false;
    Vector3 PlayerPos;
    Vector3 SwarmToPlayer = Vector3.zero;
    //float chasingSpeed;
    public override void EnterState(SwarmStates states)
    {
        //Debug.Log("Swarm Chase");
        PlayerPos = states.playerPos;
        states.animator.SetBool("RunState", true);
    }

    public override void UpdatePhysicsState(SwarmStates states)
    {
        ChasingMovement(states);
    }

    public override void UpdateState(SwarmStates states)
    {
        CalculatingChaseDirection(states);
        FaceDirection(states);
        if (states.weaknessDestroyed == true)
        {
            states.SwitchStates(states.DeathState);
        }
    }

    public override void OnCollisionEnter(SwarmStates states, Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            states.SwitchStates(states.AttackState);
        }
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
        //if(collider.tag == "Player")
        //{
        //    states.rb.AddForce(ChasingPlayer(states).normalized * 70.0f, ForceMode.Impulse);
        //}
    }

    public Vector3 CalculatingChaseDirection(SwarmStates states)
    {
        SwarmToPlayer = (states.player.position - states.swarmPos);

        Vector3 directionToPlayer = SwarmToPlayer;

        directionToPlayer.y = 0.0f;

        return directionToPlayer;
    }

    public void ChasingMovement(SwarmStates states)
    {
        states.rb.AddForce(CalculatingChaseDirection(states).normalized * 70.0f, ForceMode.Impulse);
    }
    public void FaceDirection(SwarmStates states)
    {
        Quaternion lookRotation = Quaternion.LookRotation(CalculatingChaseDirection(states).normalized); // GET ROTATION ANGLE
        lookRotation.x = lookRotation.z = 0.0f;
        states.transform.rotation = Quaternion.Slerp(states.transform.rotation, lookRotation, Time.deltaTime * 1.0f); // ROTATE FACE NEW DIRECTION
    }

    public override void ExitState(SwarmStates states)
    {
        states.animator.SetBool("RunState", false);
    }
}
