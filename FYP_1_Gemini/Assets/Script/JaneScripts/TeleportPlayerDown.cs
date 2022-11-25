using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerDown : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject groundFloorAutoEDoorTrigger;
    [SerializeField] private GameObject firstFloorAutoEDoorTrigger;
    bool teleportDone = false;
    public void TeleportPlayerBelow()
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 24.19f, player.transform.position.z);

        firstFloorAutoEDoorTrigger.SetActive(false);
        groundFloorAutoEDoorTrigger.SetActive(true);

        teleportDone = true;
    }

    private void Update()
    {
        if (teleportDone == true)
        {
            PlayerController.state = PlayerController.State.free; //free player movement

            teleportDone = false;
        }
    }
}
