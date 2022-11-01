using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuse_script : MonoBehaviour
{
    public GameObject fuse;
    public HumanoidLandInput input;
    public GameObject prisonFuse, labFuse;
    public GameObject endingPanel;
    public GameObject interactPanel;
    public GameObject player;

    private void Update()
    {
        if (prisonFuse.activeInHierarchy && labFuse.activeInHierarchy)
        {
            endingPanel.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "playerFront")
        {
            interactPanel.SetActive(true);
            if (input.InteractIsPressed == true)
            {
                if (Inventory.prisonFuzeObtained && fuse.name == "prison fuse")
                {
                    fuse.SetActive(true);
                }

                if (Inventory.labFuzeObtained && fuse.name == "lab fuse")
                {
                    fuse.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "playerFront")
        {
            interactPanel.SetActive(false);
        }
    }
}

