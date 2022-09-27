using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phs2_Move : Phsr2_Abstract
{
    Animator anim;
    GameObject player;
    float speed;
    float timer;
    public override void EnterState(Phaser2_Manager Phsr)
    {
        Debug.Log("Move");
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 100;
        timer = 0;
    }

    public override void OnCollisionEnter(Phaser2_Manager phsr, Collision col)
    {
    }

    public override void OnTriggerEnter(Phaser2_Manager phsr, Collider col)
    {
    }

    public override void OnTriggerStay(Phaser2_Manager phsr, Collider col)
    {
    }

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
    }
    public void MoveAroundPlayer(Phaser2_Manager phsr)
    {
        if (phsr.AliveP1)
        {
            if(timer > 2)
            {
                phsr.SwitchState(phsr.Attack);
            }
            else
            {
                phsr.transform.RotateAround(player.transform.position, new Vector3(0, 1, 0), speed * Time.deltaTime);
                //phsr.transform.position = Vector3.MoveTowards( phsr.transform.position ,player.transform.position, 100f);
            }
        }
    }
}
