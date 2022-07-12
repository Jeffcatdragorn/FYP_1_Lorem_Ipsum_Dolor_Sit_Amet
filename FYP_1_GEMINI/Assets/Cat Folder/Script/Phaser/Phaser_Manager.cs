using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phaser_Manager : MonoBehaviour
{
    Phsr_Abstract current_state;

    public Phs_idle Idle = new Phs_idle();
    public Phs_Patrol Patrol = new Phs_Patrol();
    public Phs_Teleport Teleport = new Phs_Teleport();
    public Phs_Attack Attack = new Phs_Attack();
    public Phs_Melee Melee = new Phs_Melee();
    public Phs_Dead Dead = new Phs_Dead();
    
    [Header ("============= Health Manager =============")]
    public int health;
    public bool Alive
    {
        get
        {
            return health > 0;
        }
    }
    
    [Header("============= Idle =============")]
    public float IdleCd;
    
    [Header("============= Patrol =============")]
    public float PatrolCd;
    
    [Header("============= Attack =============")]
    public float AttackCd;
    public float AttackRange;
    public float MeleeRate;
    public float MeleeCd;
    
    [Header("============= Teleport =============")]
    public int TeleportCounter;
    public float teleportTimer;
    public float teleportCd;
    public float TeleportCdIn;
    public float TeleportCdOut;
    public float xRange;
    public float yRange;
    public float zRange;
    public Transform[] waypoint;


    void Start()
    {
        current_state = Idle;
        current_state.EnterState(this);
    }

    void Update()
    {
        current_state.UpdateState(this);
        teleportTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        current_state.OnCollisionEnter(this, collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        current_state.OnTriggerEnter(this,other);
    }

    private void OnTriggerStay(Collider other)
    {
        current_state.OnTriggerStay(this, other);
    }

    public void SwitchState(Phsr_Abstract state)
    {
        if(current_state != null)
        {
            current_state.ExitState(this);
        }
        current_state = state;

        state.EnterState(this);
    }


}
