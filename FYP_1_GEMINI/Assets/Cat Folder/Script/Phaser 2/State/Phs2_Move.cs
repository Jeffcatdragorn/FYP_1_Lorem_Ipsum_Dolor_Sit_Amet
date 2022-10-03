using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Phs2_Move : Phsr2_Abstract
{
    Animator anim;
    GameObject player;
    NavMeshAgent agent;
    int num;

    float timer;
    public override void EnterState(Phaser2_Manager Phsr)
    {
        //Debug.Log("Move");
        anim = Phsr.GetComponent<Animator>();
        anim.SetBool("walk", true);
        player = GameObject.FindGameObjectWithTag("Player");
        timer = 0;
        agent = Phsr.GetComponent<NavMeshAgent>();
        num = Random.Range(0, 2);
    }
    #region colliders / triggers
    public override void OnCollisionEnter(Phaser2_Manager phsr, Collision col)
    {
    }

    public override void OnTriggerEnter(Phaser2_Manager phsr, Collider col)
    {
    }

    public override void OnTriggerStay(Phaser2_Manager phsr, Collider col)
    {
    }
    #endregion
    public override void UpdateState(Phaser2_Manager phsr)
    {
        timer += Time.deltaTime;
        if(phsr.Alive)
        {
            MoveAroundPlayer(phsr);
        }
        phsr.transform.LookAt(player.transform.position);
    }
    public override void ExitState(Phaser2_Manager phsr)
    {
        //phsr.transform.position = new Vector3(0,0,0);
        anim.SetBool("walk", false);
    }
    public void MoveAroundPlayer(Phaser2_Manager phsr)
    {
        if (phsr.AliveP1)
        {
            if(timer > 2)
            {
                agent.ResetPath();
                phsr.SwitchState(phsr.Attack);
            }
            else
            {
                agent.ResetPath();
                phsr.transform.RotateAround(player.transform.position, new Vector3(0, 1, 0), (num == 0 ? phsr.speed : -phsr.speed) * Time.deltaTime);
                //phsr.transform.position = Vector3.MoveTowards( phsr.transform.position ,player.transform.position, 100f);
                Vector3 temp = phsr.player.transform.position;
                //temp.y = 0; // if u dont like her tilting up due to the offset of the player is too high, then adjust this line
                float distance = Vector3.Distance(phsr.player.transform.position, phsr.transform.position);
                agent.SetDestination(distance < 80 ? -temp : temp);
            }
        }
        if (phsr.AliveP2)
        {
            if (timer > 2)
            {
                agent.ResetPath();
                phsr.SwitchState(phsr.Attack);
            }
            else
            {
                agent.ResetPath();
            }


        }
    }
}
