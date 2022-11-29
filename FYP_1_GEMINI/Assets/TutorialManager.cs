using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inspectCam;
    [SerializeField] private GameObject flashlightTutorialPanel;
    [SerializeField] private GameObject tabletTutorialPanel;
    [SerializeField] private GameObject movementTutorialPanel;
    [SerializeField] private GameObject gunTutorialPanel;
    [SerializeField] private GameObject deadPanel;
    [SerializeField] private HumanoidLandInput input;
    private int flow = 0;
    private bool inspectOffFLashlight;
    private bool inspectOffTablet;
    private bool flashlightTutorialCheck;
    private bool tabletTutorialCheck;
    public static bool inspectStop;

    // Update is called once per frame
    void Update()
    {
        if(flashlightTutorialCheck == false && flow == 0)
        {
            FlashlightTutorialOn();
        }

        if (tabletTutorialCheck == false && flow == 1)
        {
            TabletTutorialOn();
        }

        if(flashlightTutorialPanel.activeInHierarchy || tabletTutorialPanel.activeInHierarchy || movementTutorialPanel.activeInHierarchy || gunTutorialPanel.activeInHierarchy || deadPanel.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void FlashlightTutorialOn()
    {
        if (inspectCam.activeInHierarchy == true && Inventory.flashlightObtained == true && inspectOffFLashlight == false)
        {
            if (input.FlashlightIsPressed == true)
            {
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                inspectStop = true;
                inspectOffFLashlight = true;
            }
        }

        if (inspectOffFLashlight == true)
        {
            flashlightTutorialPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            flashlightTutorialCheck = true;
        }
    }

    public void FlashlightTutorialOff()
    {
        flashlightTutorialPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePosition;
        inspectStop = false;
        flow = 1;
    }

    public void TabletTutorialOn()
    {
        if (inspectCam.activeInHierarchy == true && Inventory.tabletObtained == true && inspectOffTablet == false)
        {
            Debug.Log("WTF");
            if (input.FlashlightIsPressed == true)
            {
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                inspectStop = true;
                inspectOffTablet = true;
            }
        }

        if (inspectOffTablet == true)
        {
            tabletTutorialPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            tabletTutorialCheck = true;
        }
    }

    public void TabletTutorialOff()
    {
        tabletTutorialPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePosition;
        inspectStop = false;
        flow = 2;
    }
}
