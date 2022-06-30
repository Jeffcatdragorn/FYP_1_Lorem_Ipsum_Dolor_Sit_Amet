using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmos : MonoBehaviour
{
    public float sphereRadius = 1.0f;
    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, sphereRadius);
    }
}
