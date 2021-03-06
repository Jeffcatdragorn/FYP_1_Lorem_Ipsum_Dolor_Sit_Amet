using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentBehaviour : MonoBehaviour
{
    [SerializeField] HumanoidLandInput input;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" )
        {
            if(input.InteractIsPressed == true)
            {
                PlayerController.forceCrouch = true;
                other.transform.SetPositionAndRotation(transform.position, transform.rotation);
            }

            else
            {
                PlayerController.forceCrouch = false;
            }
        }
    }
}
