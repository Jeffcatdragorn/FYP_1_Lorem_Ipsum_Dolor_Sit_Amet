using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerUp : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject groundFloorAutoEDoorTrigger;
    [SerializeField] private GameObject firstFloorAutoEDoorTrigger;
    bool teleportDone = false;
    public void TeleportPlayerAbove()
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 24.19f, player.transform.position.z);

        groundFloorAutoEDoorTrigger.SetActive(false);
        firstFloorAutoEDoorTrigger.SetActive(true);
       
        teleportDone = true;
    }

    private void Update()
    {
        if(teleportDone == true)
        {
            PlayerController.state = PlayerController.State.free; //free player movement

            teleportDone = false;
        }
    }
}
