using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstParasiteTrigger : MonoBehaviour
{

    private void OnTriggerStay(Collider player)
    {

        if (player.tag == "playerFront" && PlayerController.crouchCheck == true && SavePointRespawn.domeProgress == 0)
        {
            FirstParasite.Check = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SammySammy" && SavePointRespawn.domeProgress == 0)
        {
            AudioManager.instance.PlaySound("jumpScareSound", transform.position, false);
        }
    }
}
