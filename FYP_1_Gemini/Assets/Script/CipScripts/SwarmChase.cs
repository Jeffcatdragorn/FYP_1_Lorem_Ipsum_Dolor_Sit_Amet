using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmChase : SwarmBaseStates
{
    float DistancetoPlayer = 0.0f;
    float timeInState = 0.0f;
    Vector3 PlayerPos;
    public override void EnterState(SwarmStates states)
    {
        Debug.Log("Swarm Chase");
        PlayerPos = states.playerPos;
    }

    public override void UpdateState(SwarmStates states)
    {
        if (timeInState < 10.0f)
        {
            states.transform.Translate(ChaseFormula(states) * Time.deltaTime, Space.World);
            timeInState +=Time.deltaTime;
            if (DistancetoPlayer <= 2.0f)
            {
                timeInState = 0.0f;
                states.SwitchStates(states.AttackState);
            }
        }
        else
        {
            timeInState = 0.0f;
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
    public Vector3 ChaseFormula(SwarmStates states)
    {
        Vector3 currPos = states.transform.position;

        Vector3 SwarmToPlayer = Vector3.zero;

        SwarmToPlayer = (PlayerPos - currPos).normalized;
        DistancetoPlayer = Vector3.Distance(PlayerPos, currPos) - 1;

        Vector3 chaseVelo = SwarmToPlayer * 10.0f;

        chaseVelo.y = 0.0f;

        Quaternion lookRotation = Quaternion.LookRotation((SwarmToPlayer - states.swarmPos).normalized); // GET ROTATION ANGLE
        states.transform.rotation = Quaternion.Slerp(states.transform.rotation, lookRotation, Time.deltaTime * 4.0f); // ROTATE FACE NEW DIRECTION

        return chaseVelo;
    }
}
