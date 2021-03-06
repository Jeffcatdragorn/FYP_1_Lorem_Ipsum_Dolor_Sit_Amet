using UnityEngine;

public abstract class SwarmBaseStates
{
    public abstract void EnterState(SwarmStates states);

    public abstract void UpdateState(SwarmStates states);

    public abstract void OnCollisionEnter(SwarmStates states);

    public abstract void OnTriggerEnter(SwarmStates states, Collider collider);

    public abstract void OnTriggerExit(SwarmStates states, Collider collider);
}
