using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Manager : MonoBehaviour
{
    Enemies_Abstract current_state;

    public Idle IdleState = new Idle();
    public patrol PatrolState = new patrol();
    public attack AttackState = new attack();
    public teleport TeleportState = new teleport();

    void Start()
    {
        //starting state for the state machine
        current_state = IdleState;
        //entering this current state
        current_state.EnterState(this);
    }

    void Update()
    {
        //will carry any logic from the current state every frame
        current_state.UpdateState(this);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        current_state.OnCollisionEnter(this, collision);
    }

    public void SwitchState(Enemies_Abstract state)
    {
        // transition to the new pass state
        current_state = state;
        // entering the current new state
        state.EnterState(this);
    }
}
