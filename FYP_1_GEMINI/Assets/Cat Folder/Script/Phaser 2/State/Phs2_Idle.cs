using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phs2_Idle : Phsr2_Abstract
{
    Animator animator;
    float distance;
    public override void EnterState(Phaser2_Manager Phsr)
    {
    }
    
    public override void UpdateState(Phaser2_Manager phsr)
    {
        if (phsr.Alive) Idling(phsr);
    }
    #region colliders and triggers
    public override void OnCollisionEnter(Phaser2_Manager phsr, Collision col)
    {
    }
    
    public override void OnTriggerEnter(Phaser2_Manager phsr, Collider col)
    {
    }
    
    public override void OnTriggerStay(Phaser2_Manager phsr, Collider col)
    {
    }

    public override void ExitState(Phaser2_Manager phsr)
    {
    }
    #endregion
    public void Idling(Phaser2_Manager phsr)
    {
        distance = Vector3.Distance(phsr.player.transform.position, phsr.transform.position);
        if (distance < phsr.playerRange) phsr.SwitchState(phsr.Attack);
    }
}
