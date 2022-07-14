using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TabletDoorScanning : MonoBehaviour
{
    public HumanoidLandInput input;
    public string doorName;
    public TextMeshProUGUI doorText;
    public GameObject doorPanel;
    public ButtonManager buttonManager;
    [SerializeField] float ScannerCooldownCounter;
    [SerializeField] float ScannerUICooldown;
    [SerializeField] private Animator normalDoorAnimator = null;
    [SerializeField] private string doorSlideOpen = "DoorSlideOpen";
    private bool doorIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
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

        if(doorIsOpen == true)
        {
            doorPanel.GetComponentInChildren<Button>().interactable = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(input.InteractIsPressed == true && Inventory.tabletObtained == true && ScannerCooldownCounter == 0.0f)
            {
                doorPanel.SetActive(true);
                buttonManager.EnableMouseCursor();
                ScannerCooldownCounter = ScannerUICooldown;
            }
        }
    }

    public void OpenDoor()
    {
        normalDoorAnimator.Play(doorSlideOpen, 0, 0.0f);
        //AudioManager.instance.PlaySound("doorOpening", gameObject.transform);
        doorIsOpen = true;
    }
}
