using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManagerJane : MonoBehaviour
{
    TankAbstractJane currentState;

    public TankIdleStateJane idle = new TankIdleStateJane();
    public TankPatrolStateJane patrol = new TankPatrolStateJane();
    public TankAttackStateJane attack = new TankAttackStateJane();
    public TankDeadStateJane dead = new TankDeadStateJane();

    [Header("-----Health Condition-----")]
    public bool isAlive;

    [Header("-----Idle State-----")]
    public float idleTime;

    [Header("-----Patrol State-----")]
    public float patrolTime;
    public Transform[] patrolPoints;

    [Header("-----Attack State-----")]
    public Transform playerTransform;
    public float chargingAttackTime;
    public GameObject chargingAttackParticle;

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

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(this, other);
    }

    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(this, other);
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
