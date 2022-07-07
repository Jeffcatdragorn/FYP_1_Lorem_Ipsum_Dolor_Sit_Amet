using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmChase : SwarmBaseStates
{
    float DistancetoPlayer = 0.0f;
    float timeInState = 0.0f;
    Vector3 playerPos;
    public override void EnterState(SwarmStates states)
    {
        Debug.Log("Swarm Chase");
    }

    public override void UpdateState(SwarmStates states)
    {
        if (timeInState < 10.0f)
        {
            states.transform.Translate(ChaseFormula(states) * Time.deltaTime, Space.World);
            timeInState +=Time.deltaTime;
            if (DistancetoPlayer <= 1.5f)
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
        Vector3 PlayerPos = playerPos;

        Vector3 SwarmToPlayer = Vector3.zero;

        SwarmToPlayer = (PlayerPos - currPos).normalized;
        DistancetoPlayer = Vector3.Distance(PlayerPos, currPos) - 1;

        Vector3 chaseVelo = SwarmToPlayer * 10.0f;

        chaseVelo.y = 0.0f;

        //states.transform.LookAt(SwarmToPlayer);

        return chaseVelo;
    }
}
