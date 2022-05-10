using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : Enemies_Abstract
{
    public override void EnterState(Enemies_Manager enemy)
    {
        Debug.Log("Entered Patrol State");
    }

    public override void UpdateState(Enemies_Manager enemy)
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("fak");
        }
    }

    public override void OnCollisionEnter(Enemies_Manager enemy, Collision collision)
    {
    }

    public override void ExitState(Enemies_Manager enemy)
    {
    }
}
