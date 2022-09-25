using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrolStateJane : TankAbstractJane
{
    public override void EnterState(TankManagerJane Tank)
    {

    }

    public override void ExitState(TankManagerJane Tank)
    {

    }

    public override void OnCollisionEnter(TankManagerJane Tank, Collision collider)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(TankManagerJane Tank, Collider collider)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(TankManagerJane Tank, Collider collider)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(TankManagerJane Tank)
    {

    }
}
