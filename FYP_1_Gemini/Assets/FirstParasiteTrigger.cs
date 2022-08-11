using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstParasiteTrigger : MonoBehaviour
{

    private void OnTriggerStay(Collider player)
    {

        if (player.tag == "Player" && PlayerController.crouchCheck == true)
        {
            FirstParasite.Check = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SammySammy")
        {
            AudioManager.instance.PlaySound("jumpScareSound", transform.position, false);
        }
    }
}
