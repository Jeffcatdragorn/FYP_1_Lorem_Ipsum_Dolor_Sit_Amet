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
    private float dist; 
    private NavMeshAgent navmeshAgent;
    private GameObject player;

    [Header("Teleport ")]
    public float teleportTime = 3.0f;
    private float teleportTimer = .0f;
    public float xRange;
    public float yRange;
    public float zRange;
    public bool teleport_B = false;
    public int teleportCount = 0;
    public int teleportRandomCount;
    public float Dist 
    {
       get
       {
            return dist = Vector3.Distance(transform.position, waypoint[waypointIndex].position);
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

        if (teleport_B)
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
            //Debug.Log("fak off");
            teleport_B = true;
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
        Debug.Log("i am teleporting");
        // - play enter portal animation on contact
        //- ignore all collision
        Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(), GetComponent<BoxCollider>());
        //- let the random numbers roll
        float xPos = Random.Range(-xRange, xRange);
        float yPos = Random.Range(0, yRange);
        float zPos = Random.Range(-zRange, zRange);

        //- wait for x seconds
        teleportTimer += Time.deltaTime;
        if (teleportTimer > teleportTime)
        {
            Debug.Log("i am done teleporting");
            teleport_B = false;
            teleportTimer = 0;
            //- set the current random position
            transform.position = new Vector3(xPos,yPos,zPos);
            //- play exit portal animation
            //- acknowledge collision again
            Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(), GetComponent<BoxCollider>(), false);
        }
        #endregion
    }

    public void TeleportingCount()
    {
        if (teleportCount >= teleportRandomCount)
        {
            //stop teleporting
        }
    }


    #endregion
}
