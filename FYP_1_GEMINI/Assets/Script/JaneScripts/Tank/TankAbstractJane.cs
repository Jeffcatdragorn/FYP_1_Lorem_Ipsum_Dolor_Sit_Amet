using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankAbstractJane
{
    public abstract void EnterState(TankManagerJane Tank);
    public abstract void UpdateState(TankManagerJane Tank);
    public abstract void OnCollisionEnter(TankManagerJane Tank, Collision collider);
    public abstract void OnTriggerEnter(TankManagerJane Tank, Collider collider);
    public abstract void OnTriggerStay(TankManagerJane Tank, Collider collider);
    public abstract void ExitState(TankManagerJane Tank);
}
