using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorGoDownTrigger : MonoBehaviour
{
    [SerializeField] private Animator normalDoorAnimator = null;
    [SerializeField] private string doorSlideClose = "ElevatorDoorClose";
    [SerializeField] private string transition = "ElevatorTransition1";
    [SerializeField] private TabletDoorScanning tabletDoorScanning;

    [Header("DOOR LIGHT")]
    public bool doorLight = false;
    public MeshRenderer doorLightMeshRenderer;
    public Material redDoorLightMaterial;
    public Material greenDoorLightMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (TabletDoorScanning.doorIsOpen == true || tabletDoorScanning.doorIsOpen2 == true)
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

                if (tabletDoorScanning != null)
                {
                    tabletDoorScanning.doorIsOpen2 = false;
                }

                PlayerController.state = PlayerController.State.movementLock; //lock player movement

                Invoke("ElevatorGoDownTransition", 2f);
            }
        }
    }

    void ElevatorGoDownTransition()
    {
        normalDoorAnimator.Play(transition, 0, 0.0f);

        gameObject.SetActive(false);
    }
}
