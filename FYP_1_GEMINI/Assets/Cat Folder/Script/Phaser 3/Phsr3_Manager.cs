using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phsr3_Manager : MonoBehaviour
{
    Phsr3_Abstract current_state;

    public Phsr3_Idle Idle = new Phsr3_Idle();
    public Phsr3_Attack Attack = new Phsr3_Attack();
    public Phsr3_Death Death = new Phsr3_Death();

    private Animator anim;

    public GameObject player;
    public GameObject generatorFuse;
    

    [Header("============= Health Manager =============")]
    public int health;
    public bool AliveP1
    {
        get
        {
            return TeslaCoilBehaviour.teslaProgress < 2;
            //return health > 50;
        }
    }
    public bool AliveP2
    {
        get
        {
            return TeslaCoilBehaviour.teslaProgress >= 2;
            //return health <= 50;
        }
    }
    public bool Alive
    {
        get
        {
            return TeslaCoilBehaviour.teslaProgress < 4;
            //return health > 0;
        }
    }

    [Header("============= Idle =============")]
    public GameObject triggerToStartAttack;

    [Header("============= multi Attack =============")]
    public float moveSpeedMulti;
    private Vector3 startPoint;
    float radius;

    [Header("============= single Attack =============")]
    public float moveSpeedSingle;
    public GameObject electricBall;
    public Transform electricBallPosition;

    [Header("============= Attack Settings =============")]
    public float cdForP1;
    public float cdForP2;

    void Start()
    {
        current_state = Idle;
        current_state.EnterState(this);
        radius = 5;
        anim = gameObject.GetComponent<Animator>();
        //AudioManager.instance.PlaySound("cat", transform.position, true);
    }

    void Update()
    {
        if (Alive)
        {
        current_state.UpdateState(this);
        transform.LookAt(player.transform.position);
        }
        else
        {
            anim.SetBool("dead", true);
        }
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
    public void SwitchState(Phsr3_Abstract state)
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
        AudioManager.instance.PlaySound("phsrAtt1", this.transform.position, true);
        GameObject ball;
        ball = Instantiate(electricBall, electricBallPosition.position, electricBallPosition.rotation);
        float xPosOfBallDir = player.transform.position.x - transform.position.x;
        float zPosOfBallDir = player.transform.position.z - transform.position.z;

        Vector3 ballVector = new Vector3(xPosOfBallDir, 0, zPosOfBallDir);
        Vector3 ballMoveDir = ballVector * (AliveP1 == true ? (moveSpeedSingle * 2) : moveSpeedSingle) * Time.deltaTime;

        ball.GetComponent<Rigidbody>().velocity = new Vector3(ballMoveDir.x, 0, ballMoveDir.z);
    }

    public void CreateMultiLightningBall(int numOfBalls, float yVal)
    {
        AudioManager.instance.PlaySound("phsrAtt2",this.transform.position,true);
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
            Vector3 ballMoveDir = (ballVector - startPoint).normalized * (AliveP1 == true ? (moveSpeedMulti*2) : moveSpeedMulti);

            var ball = Instantiate(electricBall, startPoint, Quaternion.identity);
            ball.GetComponent<Rigidbody>().velocity = /*new Vector3(1, 1, 1);*/
            new Vector3(ballMoveDir.x, 0, ballMoveDir.z);
            ball.transform.position = new Vector3(ball.transform.position.x, yVal, ball.transform.position.z);

            angle += angleStep;
        }
    }

    public void MultiAttack()
    {
        CreateMultiLightningBall(20,10);
    }
    #endregion

    public void EnableTheFuse()
    {
        generatorFuse.SetActive(true);
    }

    public void Audio_Scream()
    {
        AudioManager.instance.PlaySound("phsrScream", this.transform.position, true);
    }
    public void Audio_Die()
    {
        AudioManager.instance.PlaySound("phsrDie", this.transform.position, true);
    }
}
