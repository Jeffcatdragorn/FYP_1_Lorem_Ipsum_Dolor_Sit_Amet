using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : Enemies_Abstract
{
    public override void EnterState(Enemies_Manager enemy)
    {
        //Debug.Log("teleporting");
    }

    public override void UpdateState(Enemies_Manager enemy)
    {
        if (enemy.health > 0)
        {
            Teleport(enemy);
        }
    }

    public override void OnCollisionEnter(Enemies_Manager enemy, Collision collision)
    {
    }

    public override void ExitState(Enemies_Manager enemy)
    {
        //Debug.Log("exit teleporting");
    }
    public void Teleport(Enemies_Manager enemy)
    {
        if (!enemy.canTeleport && enemy.teleportCount == enemy.teleportRandomCount)
        {
            enemy.SwitchState(enemy.IdleState);
        }
    }
}
