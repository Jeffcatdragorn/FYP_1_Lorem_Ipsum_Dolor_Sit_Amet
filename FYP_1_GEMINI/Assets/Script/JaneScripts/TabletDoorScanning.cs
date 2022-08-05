using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TabletDoorScanning : MonoBehaviour
{
    public HumanoidLandInput input;
    public string doorName;
    //private string currentDoorName;
    public TextMeshProUGUI doorText;
    public GameObject doorPanel;
    //public GameObject connectedDoor;
    public ButtonManager buttonManager;
    [SerializeField] float ScannerCooldownCounter;
    [SerializeField] float ScannerUICooldown;
    [SerializeField] private Animator normalDoorAnimator = null;
    [SerializeField] private string doorSlideOpen = "DoorSlideOpen";
    private bool doorIsOpen = false;
    public GameObject flashlightText;
    public GameObject tabletText;
    private bool flashlightCheck;
    private bool tabletCheck;

    // Start is called before the first frame update
    void Start()
    {
        doorText.text = doorName;
        //currentDoorName = doorText.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScannerCooldownCounter > 0)
        {
            ScannerCooldownCounter -= Time.deltaTime;
        }

        if (ScannerCooldownCounter <= 0)
        {
            ScannerCooldownCounter = 0.0f;
        }

        

        if (doorIsOpen == true)
        {
            doorPanel.SetActive(false);
            //doorPanel.GetComponentInChildren<Button>().interactable = false; // for clicking button UI opening door only
            //doorIsOpen = false;
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            //if (input.InteractIsPressed == true && Inventory.tabletObtained == true && ScannerCooldownCounter == 0.0f)//for clicking button UI opening door only
            //{
            //    //if(doorText.text != currentDoorName)
            //    //{
            //    //    doorText.text = doorName;
            //    //    doorPanel.GetComponentInChildren<Button>().interactable = true;
            //    //    doorPanel.GetComponentInChildren<Button>()
            //    //}

            //    doorPanel.SetActive(true);
            //    buttonManager.EnableMouseCursor(); 
            //    ScannerCooldownCounter = ScannerUICooldown;
            //}

            if (input.InteractIsPressed == true && Inventory.tabletObtained == true && ScannerCooldownCounter == 0.0f)
            {
                OpenDoor();

                ScannerCooldownCounter = ScannerUICooldown;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorText.text = doorName;


            if (doorName == "Prison Dome Gate")
            {
                if (Inventory.tabletObtained == true)
                {
                    if (Inventory.flashlightObtained == false)
                    {
                        flashlightText.SetActive(true);
                        doorPanel.SetActive(false);
                        flashlightCheck = false;
                    }
                    else
                    {
                        doorPanel.SetActive(true);
                        flashlightCheck = true;
                    }
                }
                else
                {
                    doorPanel.SetActive(false);
                }

            }
            else
            {
                if (Inventory.tabletObtained == false)
                {
                    tabletText.SetActive(true);
                    doorPanel.SetActive(false);
                    tabletCheck = false;
                }
                else
                {
                    doorPanel.SetActive(true);
                    tabletCheck = true;
                }
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorPanel.SetActive(false);
        flashlightText.SetActive(false);
        tabletText.SetActive(false);
    }

    public void OpenDoor()
    {
        if (doorName == "Prison Dome Gate")
        {
            if(flashlightCheck == true) {
                normalDoorAnimator.Play(doorSlideOpen, 0, 0.0f);

                AudioManager.instance.PlaySound("doorOpening", normalDoorAnimator.gameObject.transform.GetChild(0).transform.position, true);
                //AudioManager.instance.PlaySound("doorOpening", normalDoorAnimator.gameObject.transform.position, true);
                //AudioManager.instance.PlaySound("doorOpening", gameObject.transform.position, true);
                TVTriggerBehaviour.tvCheck = true;
                doorIsOpen = true;
            }
            else
            {
                TVTriggerBehaviour.tvCheck = false;
            }
        }
        else
        {
            if (tabletCheck == true)
            {
                normalDoorAnimator.Play(doorSlideOpen, 0, 0.0f);

                AudioManager.instance.PlaySound("doorOpening", normalDoorAnimator.gameObject.transform.GetChild(0).transform.position, true);
                //AudioManager.instance.PlaySound("doorOpening", normalDoorAnimator.gameObject.transform.position, true);
                //AudioManager.instance.PlaySound("doorOpening", gameObject.transform.position, true);
                TVTriggerBehaviour.tvCheck = true;
                doorIsOpen = true;
            }
        }
    }
}
