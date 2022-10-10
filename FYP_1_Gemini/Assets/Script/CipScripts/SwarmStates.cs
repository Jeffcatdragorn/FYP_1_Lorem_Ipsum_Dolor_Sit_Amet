using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmStates : MonoBehaviour
{
    SwarmBaseStates currentSwarmState; //signifies which state the swarm is in rn.
    public SwarmAttack AttackState = new SwarmAttack();
    public SwarmPatrol PatrolState = new SwarmPatrol();
    public SwarmIdle IdleState = new SwarmIdle();
    public SwarmChase ChaseState = new SwarmChase();
    public SwarmAvoidObstacles AvoidState = new SwarmAvoidObstacles();

    public  bool weaknessDestroyed;
    public float timeswitchState = 3.0f;
    public float switchPatrolLocation = 10.0f;
    public int swarmMaxHealth;
    int swarmCurrHealth;

    public Vector3 swarmPos;
    public Vector3 playerPos;

    void Start() 
    {
        currentSwarmState = IdleState;
        
        currentSwarmState.EnterState(this);

        swarmMaxHealth = 4;
    }

    void Update()
    {
        if (weaknessDestroyed == false)
        {
            swarmPos = this.gameObject.transform.position;
            playerPos = GameObject.Find("Player").transform.position;
            currentSwarmState.UpdateState(this);
        }
        else
            Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        currentSwarmState.OnTriggerEnter(this, other);
    }

    public  void OnTriggerExit(Collider other)
    {
        currentSwarmState.OnTriggerExit(this, other);
    }

    public void OnTriggerStay(Collider other)
    {
        currentSwarmState.OnTriggerStay(this, other);
    }
    public void SwitchStates(SwarmBaseStates states)
    {
        currentSwarmState = states;
        states.EnterState(this);
    }
}
