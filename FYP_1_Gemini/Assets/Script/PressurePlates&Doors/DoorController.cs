using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    [SerializeField] private Animator pressurePlate = null;

    [Header("Door type")] //only tick one door type in the inspector
    [SerializeField] private bool openOnceOnlyDoor = false;

    [Header("Pressure Plate Type")] //only tick one pressure plate type in the inspector
    [SerializeField] private bool openDoorTrigger = false;
    //[SerializeField] private bool closeDoorTrigger = false;

    [Header ("Animation names")] //just in case got different animations for doors and pressure plates
    //[SerializeField] private string doorOpen = "DoorOpening";
    //[SerializeField] private string doorClose = "DoorClosing";
    [SerializeField] private string doorSlideOpen = "DoorSlideOpen";
    [SerializeField] private string doorSlideClose = "DoorSlideClose";
    [SerializeField] private string pressurePlatePressed = "PPlatePressed";
    [SerializeField] private string pressurePlateReleased = "PPlateReleased";

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) //change the tag to the object that is going to be placed on the pressure plate
        {
            if (openDoorTrigger == true)
            {
                door.Play(doorSlideOpen, 0, 0.0f);
                pressurePlate.Play(pressurePlatePressed, 0, 0.0f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) //change the tag to the object that is going to be placed on the pressure plate
        {
            //closeDoorTrigger = true;
            if(openOnceOnlyDoor == false)
            {
                door.Play(doorSlideClose, 0, 0.0f);
                pressurePlate.Play(pressurePlateReleased, 0, 0.0f);
            }
        }
    }
}
