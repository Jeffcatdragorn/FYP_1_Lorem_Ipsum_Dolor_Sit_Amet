using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Phs_Teleport : Phsr_Abstract
{
    float timerIn;
    GameObject Player;
    NavMeshAgent navmeshAgent;
    float timerOut;
    int counter;
    bool transformAlreadyMove;
    float xPos;
    float yPos;
    float zPos;

    public override void EnterState(Phaser_Manager Phsr)
    {
        //Debug.Log("Teleport");
        Player = GameObject.FindGameObjectWithTag("Player");
        Phsr.transform.LookAt(Player.transform.position);
        Physics.IgnoreCollision(Player.GetComponent<CapsuleCollider>(), Phsr.GetComponent<BoxCollider>());
        navmeshAgent = Phsr.GetComponent<NavMeshAgent>();

        navmeshAgent.ResetPath();

    }

    public override void ExitState(Phaser_Manager phsr)
    {
        //Debug.Log("Exit Teleport");
    }

    public override void OnCollisionEnter(Phaser_Manager phsr, Collision col)
    {
    }

    public override void OnTriggerEnter(Phaser_Manager phsr, Collider col)
    {
    }

    public override void OnTriggerStay(Phaser_Manager phsr, Collider col)
    {
    }

    public override void UpdateState(Phaser_Manager phsr)
    {
        //Debug.Log("Teleporting");
        if (phsr.Alive)
        {
            phsr.transform.LookAt(Player.transform.position);
            Teleporting(phsr);
        }

    }

    void Teleporting(Phaser_Manager phsr)
    {
        if (phsr.teleportTimer > phsr.teleportCd)
        {
            if (counter < phsr.TeleportCounter)
            {
                if (timerIn < phsr.TeleportCdIn)
                {
                    //Debug.Log("in");

                    timerIn += Time.deltaTime;
                    // turn off the nightShade
                    //yPos = Random.Range(0, phsr.yRange);
                    xPos = Random.Range(-phsr.xRange + Player.transform.position.x, phsr.xRange + Player.transform.position.x);
                    yPos = Random.Range(0, Player.transform.position.y);
                    zPos = Random.Range(-phsr.zRange + Player.transform.position.z, phsr.zRange + Player.transform.position.z);
                }
                else
                {
                    //Debug.Log("out");
                    timerOut += Time.deltaTime;
                    if (timerOut < phsr.TeleportCdOut)
                    {
                        if (transformAlreadyMove == false)
                        {
                            Player = GameObject.FindGameObjectWithTag("Player");
                            phsr.transform.LookAt(Player.transform.position);
                            phsr.transform.position = new Vector3(xPos,yPos,zPos);

                            Physics.IgnoreCollision(Player.GetComponent<CapsuleCollider>(), phsr.GetComponent<BoxCollider>(), false);
                            //Debug.Log(counter);
                            transformAlreadyMove = true;
                        }
                    }
                    else
                    {
                        counter++;
                        timerIn = 0;
                        timerOut = 0;
                        transformAlreadyMove = false;
                    }
                }
            }
            else
            {
                phsr.teleportTimer = 0;
                phsr.SwitchState(phsr.Attack);
            }
        }
        else
        {
            phsr.SwitchState(phsr.Attack);
        }
    }
}
