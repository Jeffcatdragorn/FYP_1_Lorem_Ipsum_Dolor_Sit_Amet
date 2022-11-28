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
    //public float IdleCd;
    public float playerRange;
    [Header("============= Attack =============")]
    //public float AttackCd;
    public GameObject electricBall;
    public Transform electricBallPosition;
    public bool test1, test2;

    [Header("============= Move =============")]
    public float speed;
    
    [Header("============= multiAttack =============")]
    public float moveSpeed;
    private Vector3 startPoint;
    float radius;
    public GameObject generatorPos;
    void Start()
    {
        current_state = Idle;
        current_state.EnterState(this);
        radius = 5f;
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

    #region attacking stuff
    public void CreateLightningBall()
    {
        if (AliveP1)
        {
            GameObject ball;
            ball = Instantiate(electricBall, electricBallPosition.position, electricBallPosition.rotation);
        }
    }

    public void CreateMultiLightningBall(int numOfBalls, float yVal)
    {
        startPoint = transform.position;

        float angleStep = 360f / numOfBalls;
        float angle;
        float tempNum = Random.Range(0, 3);
        switch (tempNum)
        {
            case 0:
                angle = angleStep * 2;
                break;
            case 1:
                angle = angleStep / 2;
                break;
            default:
                angle = 0;
                break;
        }
        for (int i = 0; i < numOfBalls; i++)
        {
            float xPosOfBallDir = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float zPosOfBallDir = transform.position.z + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 ballVector = new Vector3(xPosOfBallDir, 0, zPosOfBallDir);
            Vector3 ballMoveDir = (ballVector - startPoint).normalized * moveSpeed;

            var ball = Instantiate(electricBall, startPoint, Quaternion.identity);
            ball.GetComponent<Rigidbody>().velocity = /*new Vector3(1,1,1);*/
            new Vector3(ballMoveDir.x, 0, ballMoveDir.z);
            ball.transform.position = new Vector3(ball.transform.position.x, yVal, ball.transform.position.z);

            angle += angleStep;
        }
    } 
    #endregion

    public void TakeDamage(int hp)
    {
        if (AliveP1)
        {
            health -= hp;
            Debug.Log("health decrease" + health );
        }
    }
}
