using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankIdleStateJane : TankAbstractJane
{
    float timer;

    public override void EnterState(TankManagerJane Tank)
    {
        timer = 0;
        Debug.Log("idle");
    }

    public override void UpdateState(TankManagerJane Tank)
    {
        if (Tank.isAlive == true)
        {
            Idle(Tank);
        }
    }
    public override void OnCollisionEnter(TankManagerJane Tank, Collision collider)
    {
        //if (collider.gameObject.tag == "Player") //tank body collider
        //{
        //    Tank.SwitchState(Tank.attack);
        //}
    }

    public override void OnTriggerEnter(TankManagerJane Tank, Collider collider)
    {
        //if (collider.tag == "Player") //vision collider
        //{
        //    Tank.SwitchState(Tank.attack);
        //}
    }

    public override void OnTriggerStay(TankManagerJane Tank, Collider collider)
    {
        if(collider.tag == "Player") //vision collider
        {
            Tank.SwitchState(Tank.attack);
        }
    }

    public override void ExitState(TankManagerJane Tank)
    {

    }

    public void Idle(TankManagerJane Tank)
    {
        timer += Time.deltaTime;
        
        if (timer > Tank.idleTime)
        {
            Tank.SwitchState(Tank.patrol);
        }

        //Debug.Log("IDLE timer = " + timer);
    }

    public override void OnTriggerExit(TankManagerJane Tank, Collider collider)
    {
        throw new System.NotImplementedException();
    }
}
