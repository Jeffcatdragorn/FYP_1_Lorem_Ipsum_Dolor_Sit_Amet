using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : Enemies_Abstract
{
    public override void EnterState(Enemies_Manager enemy)
    {

    }

    public override void UpdateState(Enemies_Manager enemy)
    {
        if (!enemy.teleport_B && enemy.teleportCount == enemy.teleportRandomCount)
        {
            enemy.SwitchState(enemy.IdleState);
        }
    }

    public override void OnCollisionEnter(Enemies_Manager enemy, Collision collision)
    {
    }

    public override void ExitState(Enemies_Manager enemy)
    {
    }
}
