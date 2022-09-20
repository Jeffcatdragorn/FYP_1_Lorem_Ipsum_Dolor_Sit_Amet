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

    public bool testingStates;
    public float timeswitchState = 3.0f;
    public float switchPatrolLocation = 10.0f;
    public int swarmMaxHealth;
    int swarmCurrHealth;

    public Vector3 swarmPos;
    public Vector3 playerPos;

    private void Awake()
    {
        playerPos = GameObject.Find("Player").transform.position;
    }
    void Start() 
    {
        currentSwarmState = IdleState;
        
        currentSwarmState.EnterState(this);

        swarmMaxHealth = 4;
    }

    void Update()
    {
        
        swarmPos = this.gameObject.transform.position;
        
        currentSwarmState.UpdateState(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        currentSwarmState.OnTriggerEnter(this, other);
    }

    public  void OnTriggerExit(Collider other)
    {
        currentSwarmState.OnTriggerExit(this, other);
    }

    public void SwitchStates(SwarmBaseStates states)
    {
        currentSwarmState = states;
        states.EnterState(this);
    }

    public void takeDmg(int dmg)
    {
        swarmCurrHealth = swarmMaxHealth - 1;
        if(swarmCurrHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
