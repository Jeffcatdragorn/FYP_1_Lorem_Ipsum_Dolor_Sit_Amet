using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fist")
        {
            Destroy(this);
        }
    }
}
