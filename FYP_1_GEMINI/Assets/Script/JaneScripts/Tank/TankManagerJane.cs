using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManagerJane : MonoBehaviour
{
    TankAbstractJane currentState;

    public TankIdleStateJane idle = new TankIdleStateJane();
    public TankWanderStateJane wander = new TankWanderStateJane();
    public TankAttackStateJane attack = new TankAttackStateJane();
    public TankDeadStateJane dead = new TankDeadStateJane();

    [Header("Health Condition")]
    public bool isAlive;

    [Header("Idle State")]
    public float idleTime;

    // Start is called before the first frame update
    void Start()
    {
        currentState = idle;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(TankAbstractJane state)
    {
        if (currentState != null) //there is a state rn
        {
            currentState.ExitState(this); //exit first b4 switching
        }
        currentState = state; //assign a new state to it

        state.EnterState(this); //enter the new state
    }
}
