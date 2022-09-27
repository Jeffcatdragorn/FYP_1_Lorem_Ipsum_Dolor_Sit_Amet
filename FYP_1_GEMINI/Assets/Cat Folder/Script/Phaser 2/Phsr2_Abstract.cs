using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Phsr2_Abstract 
{
    public abstract void EnterState(Phaser2_Manager Phsr);
    public abstract void UpdateState(Phaser2_Manager phsr);
    public abstract void OnCollisionEnter(Phaser2_Manager phsr, Collision col);
    public abstract void OnTriggerEnter(Phaser2_Manager phsr, Collider col);
    public abstract void OnTriggerStay(Phaser2_Manager phsr, Collider col);
    public abstract void ExitState(Phaser2_Manager phsr);
}
