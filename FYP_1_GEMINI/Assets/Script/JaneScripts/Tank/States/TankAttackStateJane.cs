using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankAttackStateJane : TankAbstractJane
{
    float timer;
    bool getPlayerTempPos;
    float distanceToPlayerTempPos;
    NavMeshAgent navMeshAgent;
    Vector3 playerTempPos;

    public override void EnterState(TankManagerJane Tank)
    {
        timer = 0;
        getPlayerTempPos = false;
        Debug.Log("attack");
        playerTempPos = Vector3.zero;

        //playerTempPos = Tank.playerTransform;
        // distanceToPlayerTempPos = Vector3.Distance(Tank.transform.position, playerTempPos.position);

        Tank.chargingAttackParticle.SetActive(false);
        Tank.transform.LookAt(Tank.playerTransform.position);
        navMeshAgent = Tank.GetComponent<NavMeshAgent>();
    }

    public override void ExitState(TankManagerJane Tank)
    {
        //stop attacking animation

        //NavMeshStopAttacking(Tank);
        //Tank.SwitchState(Tank.patrol);
    }

    public override void OnCollisionEnter(TankManagerJane Tank, Collision collider)
    {
        //if (collider.gameObject.tag == "Player")
        //{
        //    detectedPlayer = true;
        //}
    }

    public override void OnTriggerEnter(TankManagerJane Tank, Collider collider)
    {
        //if (collider.tag == "Player")
        //{
        //    detectedPlayer = true;
        //}
    }

    public override void OnTriggerStay(TankManagerJane Tank, Collider collider)
    {
        //if (collider.tag == "Player")
        //{
        //    detectedPlayer = true;
        //}
    }

    public override void OnTriggerExit(TankManagerJane Tank, Collider collider)
    {
        //if (collider.tag == "Player")
        //{
        //    detectedPlayer = false;
        //    navMeshAgent.speed = 10;
        //}
    }

    public override void UpdateState(TankManagerJane Tank)
    {
        //distanceToPlayerTempPos = Vector3.Distance(playerTempPos.normalized, Tank.transform.position);

        if (Tank.isAlive)
        {
            ChargingAttack(Tank);
        }
        //Debug.Log("bool" + getPlayerTempPos);

        //PART 1
        //if (timer > Tank.chargingAttackTime + 1.0f) //to allow charging attack again
        //{
        //    timer = 0;
        //    getPlayerTempPos = false;
        //}


        //PART 2
        //distanceToPlayerTempPos = Vector3.Distance(playerTempPos.position, Tank.transform.position);

        ////Debug.Log("playerTempPos.position = " + playerTempPos.position);
        //if (distanceToPlayerTempPos < 6f && getPlayerTempPos == true) //reached playerTempPos
        //{
        //    timer = 0;
        //    getPlayerTempPos = false;

        //    Debug.Log("reached playerTempPos ");
        //}
        //Debug.Log("distanceToPlayerTempPos = " + distanceToPlayerTempPos);
    }


    void ChargingAttack(TankManagerJane Tank)
    {
        timer += Time.deltaTime;

        if(timer < Tank.chargingAttackTime) //start charging
        {
            Tank.chargingAttackParticle.SetActive(true);
            navMeshAgent.SetDestination(Tank.transform.position);

            //Debug.Log("CHARGING Attack");
        }
        else
        {
            RushAttack(Tank);
        }
        
    }

    void RushAttack(TankManagerJane Tank)
    {
            
        if (getPlayerTempPos == false) // playerTempPos = Tank.playerTransform;
        {
            playerTempPos = Tank.playerTransform.position;

            Tank.chargingAttackParticle.SetActive(false);
            navMeshAgent.speed = 80;
            navMeshAgent.acceleration = 100;

            navMeshAgent.destination = playerTempPos; //chasing forever

            getPlayerTempPos = true;

            //Debug.Log("RUSHHHHHH Attack");

        }

        distanceToPlayerTempPos = Vector3.Distance(playerTempPos, Tank.transform.position);
        Debug.Log("playerTempPos" + playerTempPos);
        Debug.Log("distanceToPlayerTempPos = " + distanceToPlayerTempPos);

        //if (distanceToPlayerTempPos < 6f) //reached playerTempPos 
        //    // num 13f is only to tell if  the tank reach the temp pos
        //{
        //    timer = 0;
        //    getPlayerTempPos = false;
        //    //NavMeshStopAttacking(Tank);
        //    //navMeshAgent.ResetPath();
        //    Tank.SwitchState(Tank.idle); // change to searching later
        //    Debug.Log("reached playerTempPos 2 ");
        //}
        //if (timer2 < )

        if (distanceToPlayerTempPos < 13f) //reached playerTempPos
        {
            timer = 0;
            getPlayerTempPos = false;
            navMeshAgent.speed = 10;
            navMeshAgent.acceleration = 8;
            NavMeshStopAttacking(Tank);
            Tank.SwitchState(Tank.idle);
            Debug.Log("reached playerTempPos ");
        }
    }

    void NavMeshStopAttacking(TankManagerJane Tank)
    {
        navMeshAgent.SetDestination(Tank.transform.position);
    }
}
