using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phsr3_Idle : Phsr3_Abstract
{

    public override void EnterState(Phsr3_Manager Phsr)
    {
        
    }


    public override void UpdateState(Phsr3_Manager phsr)
    {
        if(phsr.Alive) Idling(phsr);
    }
    #region collisions and triggers
    
    public override void OnCollisionEnter(Phsr3_Manager phsr, Collision col)
    {
    }

    public override void OnTriggerEnter(Phsr3_Manager phsr, Collider col)
    {
    }

    public override void OnTriggerStay(Phsr3_Manager phsr, Collider col)
    {
    }
    public override void ExitState(Phsr3_Manager phsr)
    {
    }
    #endregion

    private void Idling(Phsr3_Manager phsr)
    {
        if (phsr.triggerToStartAttack.active == false)
        {
            phsr.SwitchState(phsr.Attack);
        }
    }


}
