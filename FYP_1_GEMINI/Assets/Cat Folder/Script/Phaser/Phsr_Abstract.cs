using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Phsr_Abstract 
{
    public abstract void EnterState(Phaser_Manager Phsr);
    public abstract void UpdateState(Phaser_Manager phsr);
    public abstract void OnCollisionEnter(Phaser_Manager phsr, Collision col);
    public abstract void OnTriggerEnter(Phaser_Manager phsr, Collider col);
    public abstract void OnTriggerStay(Phaser_Manager phsr, Collider col);
    public abstract void ExitState(Phaser_Manager phsr);
}
