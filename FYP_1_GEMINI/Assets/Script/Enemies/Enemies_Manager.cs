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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("fak off");
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
}
