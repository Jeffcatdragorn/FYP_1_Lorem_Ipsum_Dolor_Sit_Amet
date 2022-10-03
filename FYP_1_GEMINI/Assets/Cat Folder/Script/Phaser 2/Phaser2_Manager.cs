using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phaser2_Manager : MonoBehaviour
{
    Phsr2_Abstract current_state;

    public Phs2_Idle Idle = new Phs2_Idle();
    public Phs2_Attack Attack = new Phs2_Attack();
    public Phs2_Dead Dead = new Phs2_Dead();
    public Phs2_Move Move = new Phs2_Move();

    public GameObject player;

    [Header("============= Health Manager =============")]
    public int health;
    public bool AliveP1
    {
        get
        {
            return health > 50;
        }
    }
    public bool AliveP2
    {
        get
        {
            return health <= 50;
        }
    }
    public bool Alive
    {
        get
        {
            return health > 0;
        }
    }

    [Header("============= Idle =============")]
    public float IdleCd;
    public float playerRange;
    [Header("============= Attack =============")]
    public float AttackCd;
    public GameObject electricBall;
    public Transform electricBallPosition;
    public bool test1, test2;

    [Header("============= Move =============")]
    public float speed;
    void Start()
    {
        current_state = Idle;
        current_state.EnterState(this);
    }

    void Update()
    {
        current_state.UpdateState(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        current_state.OnCollisionEnter(this, collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        current_state.OnTriggerEnter(this, other);
    }

    private void OnTriggerStay(Collider other)
    {
        current_state.OnTriggerStay(this, other);
    }

    public void SwitchState(Phsr2_Abstract state)
    {
        if (current_state != null)
        {
            current_state.ExitState(this);
        }
        current_state = state;

        state.EnterState(this);
    }

    public void CreateLightningBall()
    {
        GameObject ball;
        ball = Instantiate(electricBall, electricBallPosition.position, electricBallPosition.rotation);
    }
}
