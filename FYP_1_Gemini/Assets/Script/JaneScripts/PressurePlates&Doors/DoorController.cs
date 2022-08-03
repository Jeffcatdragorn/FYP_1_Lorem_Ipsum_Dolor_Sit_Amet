using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator normalDoorAnimator = null;
    [SerializeField] private Animator doubleDoorAnimator = null;
    [SerializeField] private Animator pressurePlate = null;

    [Header("Door type")] //only tick one door type in the inspector
    [SerializeField] private bool openOnceOnlyDoor = false;

    [Header("Pressure Plate Type")] //only tick one pressure plate type in the inspector
    [SerializeField] private bool openDoorTrigger = false;
    //[SerializeField] private bool closeDoorTrigger = false;

    [Header("Keypad Type")]
    public bool doubleDoorKeypad = false;

    [Header("For Double Door Only")]
    public GameObject secondDoubleDoor;
    [SerializeField] private string open2ndDDoor = "SlideOpen2ndDDoor";

    [Header("Current Scene Name")]
    public string currentSceneName;

    [Header ("Animation names")] //just in case got different animations for doors and pressure plates
    //[SerializeField] private string doorOpen = "DoorOpening";
    //[SerializeField] private string doorClose = "DoorClosing";
    [SerializeField] private string doorSlideOpen = "DoorSlideOpen";
    [SerializeField] private string doorSlideClose = "DoorSlideClose";
    [SerializeField] private string pressurePlatePressed = "PPlatePressed";
    [SerializeField] private string pressurePlateReleased = "PPlateReleased";

    private bool doorIsOpen = false;
    public Transform cameraObject;
    private KeycardScanner keycardScanner;

    private void Awake()
    {
       currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        keycardScanner = gameObject.GetComponent<KeycardScanner>();
        //open2ndDDoor = secondDoubleDoor.gameObject.GetComponent<DoorController>().booleanChecker;

    }

    private void OnTriggerEnter(Collider other) //JANE's NOTES: Do I need to use ONTRIGGERENTER or just ONTRIGGERSTAY??????????????????????????????????????????????????
    {
        if (other.CompareTag("Player")) //change the tag to the object that is going to be placed on the pressure plate
        {
            Solution1();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) //change the tag to the object that is going to be placed on the pressure plate
        {
            if (currentSceneName == "FloatingLevel")
            {
                //Solution2();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) //change the tag to the object that is going to be placed on the pressure plate
        {
            //closeDoorTrigger = true;
            if(openOnceOnlyDoor == false && FuseBoxBehaviour.fuseInserted == true && KeypadBehaviour.keycardInserted == true)
            {
                normalDoorAnimator.Play(doorSlideClose, 0, 0.0f);
                AudioManager.instance.PlaySound("doorOpening", cameraObject.position, true);
                pressurePlate.Play(pressurePlateReleased, 0, 0.0f);
                doorIsOpen = false;
            }
        }
    }

    private void Solution1() //if player steps on pressure plate, inserted fuse to fuse box, inserted keycard to keypad & when door is closed, then door opens
    {
        //if (currentSceneName == "FloatingLevel")
        //{
        //    //if( && doorIsOpen == false) //create a boolean to check if the scanner card is in the inventory
        //    //{
        //    //    door.Play(doorSlideOpen, 0, 0.0f);
        //    //    doorIsOpen = true;
        //    //}
        //}
        //else
        //{
        //    if (openDoorTrigger == true && FuseBoxBehaviour.fuseInserted == true && KeypadBehaviour.keycardInserted == true && doorIsOpen == false)
        //    {
        //        door.Play(doorSlideOpen, 0, 0.0f);
        //        pressurePlate.Play(pressurePlatePressed, 0, 0.0f);
        //        doorIsOpen = true;
        //    }
        //}

        if (openDoorTrigger == true && FuseBoxBehaviour.fuseInserted == true && KeypadBehaviour.keycardInserted == true && doorIsOpen == false)
        {
            normalDoorAnimator.Play(doorSlideOpen, 0, 0.0f);
            AudioManager.instance.PlaySound("doorOpening", cameraObject.position, true);
            pressurePlate.Play(pressurePlatePressed, 0, 0.0f);
            doorIsOpen = true;
        }
    }

    //private void Solution2() //currentSceneName == "FloatingLevel"
    //{
    //    if (keycardScanner.keycardScanned == true && doorIsOpen == false)
    //    {
    //        normalDoorAnimator.Play(doorSlideOpen, 0, 0.0f);
    //        AudioManager.instance.PlaySound("doorOpening", cameraObject.position);
    //        doorIsOpen = true;
    //    }
    //}

    private void Update()
    {
        if (doubleDoorKeypad == true)
        {
            if(normalDoorAnimator.GetCurrentAnimatorStateInfo(0).IsName(doorSlideOpen))
            {
                doubleDoorAnimator.Play(open2ndDDoor, 0, 0.0f);
            }
        }
    }
}
