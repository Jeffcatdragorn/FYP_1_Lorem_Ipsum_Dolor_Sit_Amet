using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TabletDoorScanning : MonoBehaviour
{
    [Header("MANAGERS")]
    public HumanoidLandInput input;
    public ButtonManager buttonManager;
    //public PlayerController playerController;
    public GameObject tabletObj;

    [Header("WARNING TEXTS")]
    public GameObject flashlightWarning = null;
    public GameObject tabletWarning = null;
    public GameObject labKeyWarning = null;
    public GameObject labControlKeyWarning = null;
    public GameObject GeneralSectorKeyWarning = null;
    private bool flashlightCheck;
    private bool tabletCheck;
    private bool labKeyCheck;
    private bool lqKeyCheck;

    [Header("DOOR")]
    public string doorName;
    public TextMeshProUGUI doorText;
    public GameObject doorPanel;
    [SerializeField] private Animator normalDoorAnimator = null;
    [SerializeField] private string doorSlideOpen = "DoorSlideOpen";

    public static bool doorIsOpen = false;
    public bool doorIsOpen2 = false;

    [Header("DOOR LIGHT")]
    public MeshRenderer doorLightMeshRenderer;
    public Material greenDoorLightMaterial;

    [Header("SCANNER")]
    [SerializeField] float ScannerCooldownCounter;
    [SerializeField] float ScannerUICooldown;
    [SerializeField] private Animator scannerAnimator = null;
    public float scanningTime = 3.0f;
    public BoxCollider scannerTrigger;

    // Start is called before the first frame update
    void Start()
    {
        tabletObj.SetActive(false);
        doorText.text = doorName;
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
        else
        {
            scannerTrigger.enabled = true; //to allow player from opening the door again
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
            if (doorName == "Prison Dome Gate")
            {
                if (input.InteractIsPressed == true && ScannerCooldownCounter == 0.0f && Inventory.tabletObtained == true && Inventory.flashlightObtained == true && doorIsOpen2 == false)
                {
                    //disable the trigger collider to avoid player spam 'G'
                    scannerTrigger.enabled = false; //to prevent player from opening the door again

                    DoorOpeningProcess();

                    ScannerCooldownCounter = ScannerUICooldown;

                    doorIsOpen2 = true;
                }
            }
            else if (doorName == "Lab Dome Gate 2")
            {
                if (input.InteractIsPressed == true && ScannerCooldownCounter == 0.0f && Inventory.tabletObtained == true && Inventory.labKeyObtained == true && doorIsOpen2 == false)
                {
                    //disable the trigger collider to avoid player spam 'G'
                    scannerTrigger.enabled = false; //to prevent player from opening the door again

                    DoorOpeningProcess();

                    ScannerCooldownCounter = ScannerUICooldown;

                    doorIsOpen2 = true;
                }
            }
            else if (doorName == "Lab Control Room" || doorName == "General Sector Dome Gate 2")
            {
                if (input.InteractIsPressed == true && ScannerCooldownCounter == 0.0f && Inventory.tabletObtained == true && Inventory.lQKeyObtained == true && doorIsOpen2 == false)
                {
                    //disable the trigger collider to avoid player spam 'G'
                    scannerTrigger.enabled = false; //to prevent player from opening the door again

                    DoorOpeningProcess();

                    ScannerCooldownCounter = ScannerUICooldown;

                    doorIsOpen2 = true;
                }
            }
            else
            {
                if (input.InteractIsPressed == true && ScannerCooldownCounter == 0.0f && Inventory.tabletObtained == true && doorIsOpen2 == false)
                {
                    //disable the trigger collider to avoid player spam 'G'
                    scannerTrigger.enabled = false; //to prevent player from opening the door again

                    DoorOpeningProcess();

                    ScannerCooldownCounter = ScannerUICooldown;

                    doorIsOpen2 = true;
                }
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
                        flashlightWarning.SetActive(true);
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
            else if (doorName == "Lab Dome Gate 2")
            {
                if(Inventory.labKeyObtained == false)
                {
                    labKeyWarning.SetActive(true);
                    doorPanel.SetActive(false);
                    labKeyCheck = false;
                }
                else
                {
                    doorPanel.SetActive(true);
                    labKeyCheck = true;
                }
            }
            else if (doorName == "Lab Control Room")
            {
                if (Inventory.lQKeyObtained == false)
                {
                    labControlKeyWarning.SetActive(true);
                    doorPanel.SetActive(false);
                    lqKeyCheck = false;
                }
                else
                {
                    doorPanel.SetActive(true);
                    lqKeyCheck = true;
                }
            }
            else if (doorName == "General Sector Dome Gate 2")
            {
                if (Inventory.lQKeyObtained == false)
                {
                    GeneralSectorKeyWarning.SetActive(true);
                    doorPanel.SetActive(false);
                    lqKeyCheck = false;
                }
                else
                {
                    doorPanel.SetActive(true);
                    lqKeyCheck = true;
                }
            }
            else
            {
                if (Inventory.tabletObtained == false)
                {
                    tabletWarning.SetActive(true);
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

        //Disable Warning Texts
        flashlightWarning.SetActive(false);
        labKeyWarning.SetActive(false);
        tabletWarning.SetActive(false);
        labControlKeyWarning.SetActive(false);
        GeneralSectorKeyWarning.SetActive(false);
    }

    public void DoorOpeningProcess()
    {
        if(doorIsOpen2 == false)
        {
            if (doorName == "Prison Dome Gate")
            {
                if (flashlightCheck == true)
                {
                    PlayerController.state = PlayerController.State.movementLock; //lock player movement

                    tabletObj.SetActive(true);
                    scannerAnimator.Play("TabletSlotIn", 0, 0.0f);
                    AudioManager.instance.PlaySound("tabletIn", scannerAnimator.gameObject.transform.position, false);

                    doorPanel.SetActive(false);

                    Invoke("TabletSlotOut", scanningTime);

                    TVTriggerBehaviour.tvCheck = true;
                }
                else
                {
                    TVTriggerBehaviour.tvCheck = false;
                }
            }
            else if (doorName == "Lab Dome Gate 2")
            {
                if (labKeyCheck == true)
                {
                    PlayerController.state = PlayerController.State.movementLock; //lock player movement

                    tabletObj.SetActive(true);
                    scannerAnimator.Play("TabletSlotIn", 0, 0.0f);
                    AudioManager.instance.PlaySound("tabletIn", scannerAnimator.gameObject.transform.position, false);

                    doorPanel.SetActive(false);

                    Invoke("TabletSlotOut", scanningTime);
                }
            }
            else if (doorName == "Lab Control Room" || doorName == "General Sector Dome Gate 2")
            {
                if (lqKeyCheck == true)
                {
                    PlayerController.state = PlayerController.State.movementLock; //lock player movement

                    tabletObj.SetActive(true);
                    scannerAnimator.Play("TabletSlotIn", 0, 0.0f);
                    AudioManager.instance.PlaySound("tabletIn", scannerAnimator.gameObject.transform.position, false);

                    doorPanel.SetActive(false);

                    Invoke("TabletSlotOut", scanningTime);
                }
            }
            else
            {
                if (tabletCheck == true)
                {
                    PlayerController.state = PlayerController.State.movementLock; //lock player movement

                    tabletObj.SetActive(true);
                    scannerAnimator.Play("TabletSlotIn", 0, 0.0f);
                    AudioManager.instance.PlaySound("tabletIn", scannerAnimator.gameObject.transform.position, false);

                    doorPanel.SetActive(false);

                    Invoke("TabletSlotOut", scanningTime);
                }
            }
        }
    }

    private void TabletSlotOut()
    {
        doorLightMeshRenderer.material = greenDoorLightMaterial;
        scannerAnimator.Play("TabletSlotOut", 0, 0.0f);
        AudioManager.instance.PlaySound("tabletOut", scannerAnimator.gameObject.transform.position, false);

        Invoke("DoorOpens", 2.5f);
    }

    private void DoorOpens()
    {
        PlayerController.state = PlayerController.State.free; //free player movement

        tabletObj.SetActive(false);
        normalDoorAnimator.Play(doorSlideOpen, 0, 0.0f);

        //AudioManager.instance.PlaySound("doorOpening", playerController.transform.position, true);
        AudioManager.instance.PlaySound("doorOpening", normalDoorAnimator.gameObject.transform.GetChild(0).transform.position, true);
        //AudioManager.instance.PlaySound("doorOpening", normalDoorAnimator.gameObject.transform.position, true);
        //AudioManager.instance.PlaySound("doorOpening", gameObject.transform.position, true);
        doorIsOpen = true;
    }
}
