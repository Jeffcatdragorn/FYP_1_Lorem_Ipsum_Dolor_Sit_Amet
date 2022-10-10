using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverScript : MonoBehaviour
{
    private float health;
    private bool done;
    private Phaser2_Manager phsr;

    private void Start()
    {
        done = false;
        health = 10;
        phsr = GameObject.FindGameObjectWithTag("Phaser").GetComponent<Phaser2_Manager>();
    }
    void Update()
    {
        if (health <= 0)
        {
            if (!done)
            {
                phsr.TakeDamage(10);
                done = true;
            }
            else
            {
                Destroy(this, 3);
            }
        }
    }

    public void DamageReceiver(int hp)
    {
        if (phsr.AliveP2)
        {
            health -= hp;
            Debug.Log("receiver's health decrease" + health);
        }
    }


}
