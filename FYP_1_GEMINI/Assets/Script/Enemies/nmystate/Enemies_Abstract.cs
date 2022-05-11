using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies_Abstract
{
    public abstract void EnterState(Enemies_Manager enemy);

    public abstract void UpdateState(Enemies_Manager enemy);

    public abstract void OnCollisionEnter(Enemies_Manager enemy, Collision collision);

    public abstract void ExitState(Enemies_Manager enemy);

}
