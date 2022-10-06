using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    [SerializeField] private Animator normalDoorAnimator = null;
    [SerializeField] private string doorSlideOpen = "DoorSlideOpen";
    [SerializeField] private string doorSlideClose = "DoorSlideClose";

    [Header("DOOR LIGHT")]
    public bool doorLight = false;
    public MeshRenderer doorLightMeshRenderer;
    public Material redDoorLightMaterial;
    public Material greenDoorLightMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(TabletDoorScanning.doorIsOpen == false)
            {
                normalDoorAnimator.Play(doorSlideOpen, 0, 0.0f);

                //SOUND
                //AudioManager.instance.PlaySound("doorOpening", playerController.transform.position, true);
                AudioManager.instance.PlaySound("doorOpening", normalDoorAnimator.gameObject.transform.GetChild(0).transform.position, true);
                //AudioManager.instance.PlaySound("doorOpening", normalDoorAnimator.gameObject.transform.position, true);
                //AudioManager.instance.PlaySound("doorOpening", gameObject.transform.position, true);

                TabletDoorScanning.doorIsOpen = true;

                if(doorLight == true)
                {
                    doorLightMeshRenderer.material = greenDoorLightMaterial;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (TabletDoorScanning.doorIsOpen == true)
            {
                normalDoorAnimator.Play(doorSlideClose, 0, 0.0f);

                //SOUND
                //AudioManager.instance.PlaySound("doorOpening", playerController.transform.position, true);
                AudioManager.instance.PlaySound("doorOpening", normalDoorAnimator.gameObject.transform.GetChild(0).transform.position, true);
                //AudioManager.instance.PlaySound("doorOpening", normalDoorAnimator.gameObject.transform.position, true);
                //AudioManager.instance.PlaySound("doorOpening", gameObject.transform.position, true);

                TabletDoorScanning.doorIsOpen = false;

                if (doorLight == true)
                {
                    doorLightMeshRenderer.material = redDoorLightMaterial;
                }    
            }
        }
    }
}