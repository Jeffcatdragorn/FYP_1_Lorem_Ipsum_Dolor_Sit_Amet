using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstParasiteTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider player)
    {
        if(player.tag == "Player" && PlayerController.forceCrouch == true)
        {
            Debug.Log("Yes");
            FirstParasite.Check = true;
        }
    }
}
