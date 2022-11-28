using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Phsr3_Abstract
{
    public abstract void EnterState(Phsr3_Manager Phsr);
    public abstract void UpdateState(Phsr3_Manager phsr);
    public abstract void OnCollisionEnter(Phsr3_Manager phsr, Collision col);
    public abstract void OnTriggerEnter(Phsr3_Manager phsr, Collider col);
    public abstract void OnTriggerStay(Phsr3_Manager phsr, Collider col);
    public abstract void ExitState(Phsr3_Manager phsr);
}
