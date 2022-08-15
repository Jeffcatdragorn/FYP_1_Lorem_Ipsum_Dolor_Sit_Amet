using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandJumpScare : MonoBehaviour
{
    public Animator handAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "playerFront")
        {
            
        }
    }
}
