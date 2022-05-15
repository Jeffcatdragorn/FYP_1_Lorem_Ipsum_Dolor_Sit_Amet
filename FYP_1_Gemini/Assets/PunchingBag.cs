using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBag : MonoBehaviour
{

    private void OnCollisionEnter(Collision fist)
    {
        if(fist.transform.tag == "Fist")
        {
            Debug.LogWarning("Collided");
        }
    }

    private void OnTriggerEnter(Collider fist)
    {
        if (fist.transform.tag == "Fist")
        {
            Debug.LogWarning("Collided");
        }
    }
}
