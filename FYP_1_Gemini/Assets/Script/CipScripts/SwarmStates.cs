using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;


public class SwarmStates : MonoBehaviour
{
    public SwarmBaseStates currentSwarmState; //signifies which state the swarm is in rn.
    public SwarmAttack AttackState = new SwarmAttack();
    public SwarmPatrol PatrolState = new SwarmPatrol();
    public SwarmIdle IdleState = new SwarmIdle();
    public SwarmChase ChaseState = new SwarmChase();
    public SwarmAvoidObstacles AvoidState = new SwarmAvoidObstacles();
    public SwarmDeath DeathState = new SwarmDeath();
    public Animator animator;
    public GameObject [] SwarmAllies;


    public Rigidbody rb;
    public  bool weaknessDestroyed;
    bool loopBroken = false;
    public bool allyDead;
    public float timeswitchState = 3.0f;
    public float switchPatrolLocation = 10.0f;
    public int swarmMaxHealth;
    int swarmCurrHealth;
    public float soundTimer;

    public Transform player;
    public Vector3 swarmPos;
    public Vector3 initSwarmPos;
    public Vector3 playerPos;

    void Start() 
    {
        currentSwarmState = IdleState;
        
        currentSwarmState.EnterState(this);

        initSwarmPos = this.gameObject.transform.position;
    }

    void Update()
    {
        playerPos = GameObject.Find("Player").transform.position;
        swarmPos = this.gameObject.transform.position;
        if (this.weaknessDestroyed == false)
        {  
            currentSwarmState.UpdateState(this);
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
            currentSwarmState.UpdateState(this);
        }

        if(loopBroken != true)
        {
            foreach (GameObject ally in SwarmAllies)
            {
                if (ally.GetComponent<BoxCollider>().enabled == false)
                {
                    allyDead = true;
                    SwitchStates(ChaseState);
                    loopBroken = true;
                    break;
                }
            }
        }


        if (currentSwarmState == IdleState || currentSwarmState == PatrolState || currentSwarmState == ChaseState)
        {
            SoundInterval();
        }
    }

    void FixedUpdate()
    {
        //if (weaknessDestroyed == false)
        //{
        //    swarmPos = this.gameObject.transform.position;
        //    //playerPos = GameObject.Find("Player").transform.position;
        //    currentSwarmState.UpdatePhysicsState(this);
        //}
        //else
        //{
        //    GetComponent<BoxCollider>().enabled = false;
        //    currentSwarmState.UpdatePhysicsState(this);
        //}
        currentSwarmState.UpdatePhysicsState(this);
 
    }

    public void OnCollisionEnter(Collision collision)
    {
        currentSwarmState.OnCollisionEnter(this, collision);
    }
    public void OnTriggerEnter(Collider other)
    {
        currentSwarmState.OnTriggerEnter(this, other);
    }

    public void OnTriggerExit(Collider other)
    {
        currentSwarmState.OnTriggerExit(this, other);
    }

    public void OnTriggerStay(Collider other)
    {
        currentSwarmState.OnTriggerStay(this, other);
    }

    public void SwitchStates(SwarmBaseStates states)
    {
        if(currentSwarmState != null)
        {
            currentSwarmState.ExitState(this);
        }
        currentSwarmState = states;
        states.EnterState(this);
    }

    void SoundInterval()
    {
        soundTimer += Time.deltaTime;

        if (soundTimer >= 3.0f)
        {
            int randomNum1 = Random.Range(0, 200);

            if (randomNum1 == 1)
            {
                int randomNum2 = Random.Range(0, 5);

                if (randomNum2 == 0)
                {
                    AudioManager.instance.PlaySoundParent("swarmIdle1", this.gameObject, true);
                }
                if (randomNum2 == 1)
                {
                    AudioManager.instance.PlaySoundParent("swarmIdle2", this.gameObject, true);
                }
                if (randomNum2 == 2)
                {
                    AudioManager.instance.PlaySoundParent("swarmIdle3", this.gameObject, true);
                }
                if (randomNum2 == 3)
                {
                    AudioManager.instance.PlaySoundParent("swarmIdle4", this.gameObject, true);
                }
                if (randomNum2 == 4)
                {
                    AudioManager.instance.PlaySoundParent("swarmIdle5", this.gameObject, true);
                }

                soundTimer = 0;
            }
        }
    }
}
