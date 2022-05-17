using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies_Manager : MonoBehaviour
{

    Enemies_Abstract current_state;

    public Idle IdleState = new Idle();
    public patrol PatrolState = new patrol();
    public attack AttackState = new attack();
    public teleport TeleportState = new teleport();
    [Header("Idle")]
    public float IdleTime = 3.0f;

    [Header("Patrol")]
    public float PatrolTime = 5.0f;
    public Transform[] waypoint;
    private int waypointIndex; 
    private float distToPoint; 
    private float distToPlayer;
    private NavMeshAgent navmeshAgent;
    private GameObject player;

    [Header("Teleport ")]
    public float teleportTime = 3.0f;
    private float teleportTimer = .0f;
    public float teleportCDTime = 3.0f;
    private float teleportCDTimer = 20.0f;
    public bool canTeleport = false;
    public bool stillNeedTeleport = false;
    public int teleportCount = 0;
    public int teleportRandomCount;
    public float xRange;
    public float yRange;
    public float zRange;
    private float xPos;
    private float yPos;
    private float zPos;

    [Header("Attack")]
    public float attackTime = 3.0f;
    public float attackRate = 3.0f;
    public bool attack = false;
    public float attackRange = 2.0f;

    public float DistToPoint 
    {
       get
       {
            return distToPoint = Vector3.Distance(transform.position, waypoint[waypointIndex].position);
       }
    }
    public float DistToPlayer
    {
        get
        {
            player = GameObject.FindGameObjectWithTag("Player");
            return distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        }
    }
    #region inputSystem
    public Tester input;
    private void Awake()
    {
        input = new Tester();
        //input.navmesh.testering.performed += x => IncreaseIndex();
    }

    #region onEnable/disAble
    private void OnEnable()
    {
        input.navmesh.Enable();
    }
    private void OnDisable()
    {
        input.navmesh.Disable();
    }
    #endregion
    #endregion
    void Start()
    {
        //starting state for the state machine
        current_state = IdleState;
        //entering this current state
        current_state.EnterState(this);

        //navmesh AI
        waypointIndex = 0;
        transform.LookAt(waypoint[waypointIndex].position);
        navmeshAgent = GetComponent<NavMeshAgent>();

        //ignoring the unnessacary collision
        player = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(), GetComponent<CapsuleCollider>());
    }
    void Update()
    {
        //will carry any logic from the current state every frame
        current_state.UpdateState(this);

        teleportCDTimer += Time.deltaTime;

        if (stillNeedTeleport)
        {
            if(teleportCount < teleportRandomCount)
            {
                canTeleport = true;
            }
            else
            {
                stillNeedTeleport = false;
                teleportCount = 0;
                teleportCDTimer = .0f;
            }
        }
        if (canTeleport)
        {
            Teleporting();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        current_state.OnCollisionEnter(this, collision);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("I saw the player");
            teleportRandomCount = Random.Range(1,4);
            if (teleportCDTimer > teleportCDTime) //cd done cooling down, start teleporting
            {
                canTeleport = true;
                stillNeedTeleport = true;
                attack = false;
            }
            else // if cd is in cool down, attack player if in range
            {
                //stop navmesh
                navmeshAgent.ResetPath();
                //atack 
                attack = true;
            }
        }
    }
    public void SwitchState(Enemies_Abstract state)
    {
        if (current_state != null)
        {
            current_state.ExitState(this);
        }
        // transition to the new pass state
        current_state = state;
        // entering the current new state
        state.EnterState(this);
    }

    #region Navmesh, Patrolling, IncreaseIndex
    public void Patrolling()
    {
        navmeshAgent.destination = waypoint[waypointIndex].position;
        Debug.Log(navmeshAgent.remainingDistance);
    }

    public void StopPatrolling()
    {
        navmeshAgent.SetDestination(transform.position);
    }

    public void IncreaseIndex()
    {
        waypointIndex++; 
        if (waypointIndex >= waypoint.Length) 
        {
            waypointIndex = 0; 
        }
    }
    #endregion

    #region teleporting
    public void Teleporting()
    {
        #region [hard mode coding]
        // disable the enemy
        // change to random transform
        // wait for X second
        // enable the enemy
        // u prob need use instance or something like so to store the data cuz once this closes,and reopen all data is reseted
        //StartCoroutine(ShowAndHide(this.gameObject, 1.0f)); // 1 second
        //IEnumerator ShowAndHide(GameObject go, float delay)
        //{
        //    go.SetActive(true);
        //    yield return new WaitForSeconds(delay);
        //    go.SetActive(false);
        //}
        #endregion

        #region [medium mode coding]
        //Debug.Log("i am teleporting");
        // - play enter portal animation on contact
        //- ignore all collision
        Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(), GetComponent<BoxCollider>());


        //- wait for x seconds
        if (teleportTimer < teleportTime)
        {
            teleportTimer += Time.deltaTime;
            //- let the random numbers roll
            xPos = Random.Range(-xRange + player.transform.position.x, xRange + player.transform.position.x);
            yPos = Random.Range(0, yRange);
            zPos = Random.Range(-zRange + player.transform.position.z, zRange + player.transform.position.z);
        }
        else if (teleportTimer > teleportTime)
        {
            //Debug.Log("i am done teleporting");
            canTeleport = false; 
            teleportTimer = 0;
            teleportCount += 1;
            //- set the current random position
            navmeshAgent.ResetPath();
            player = GameObject.FindGameObjectWithTag("Player");
            transform.LookAt(player.transform.position);
            transform.position = new Vector3(xPos,yPos,zPos);
            //- play exit portal animation
            //- acknowledge collision again
            Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(), GetComponent<BoxCollider>(), false);
        }
        #endregion
    }
    #endregion

    #region health manager
    public int health = 1;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
