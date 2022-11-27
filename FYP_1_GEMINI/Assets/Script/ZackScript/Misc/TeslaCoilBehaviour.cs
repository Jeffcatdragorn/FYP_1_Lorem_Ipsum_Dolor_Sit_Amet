using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeslaCoilBehaviour : MonoBehaviour
{
    [SerializeField] HumanoidLandInput input;
    [SerializeField] GameObject player;
    [SerializeField] GameObject interactPanel;
    [SerializeField] GameObject tabletObject;
    [SerializeField] Animator scannerAnimator;
    [SerializeField] GameObject progressPanel;
    [SerializeField] Slider progressSlider;
    [SerializeField] float cooldown;
    [SerializeField] GameObject scannerLight;
    [SerializeField] Material scannerRedLightMat;
    [SerializeField] Material scannnerGreenLightMat;

    private bool interactPanelBool;
    private bool animBool;
    private bool progressCheck;
    private bool teslaDone;
    private float cooldownTimer;
    private AnimatorStateInfo animScannerStateInfo;
    private float scannerNTime;

    public static int teslaProgress;


    private void Update()
    {
        if (progressCheck == true)
        {

            if (scannerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Tablet Slot IN"))
            {
                animScannerStateInfo = scannerAnimator.GetCurrentAnimatorStateInfo(0);
                scannerNTime = animScannerStateInfo.normalizedTime;
            }

            if (scannerNTime > 1.0f)
            {
                progressPanel.SetActive(true);
                scannerLight.GetComponent<MeshRenderer>().material = scannnerGreenLightMat;

                if (progressSlider.value > 0)
                {
                    progressSlider.value -= Time.deltaTime;
                }
            }
        }

        if (progressCheck == false)
        {
            progressPanel.SetActive(false);
        }

        if (cooldownTimer >= 0.0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if(progressSlider.value <= 0)
        {
            PlayerController.state = PlayerController.State.free;
            teslaProgress += 1;
            teslaDone = true;
            progressCheck = false;
            scannerNTime = 0.0f;

            progressSlider.value = 5;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && teslaDone == false)
        {
            if (interactPanelBool == false)
                interactPanel.SetActive(true);
            else
                interactPanel.SetActive(false);

            if(input.InteractIsPressed == true && animBool == false && cooldownTimer <= 0.0f)
            {
                PlayerController.state = PlayerController.State.movementLock;
                tabletObject.SetActive(true);
                scannerAnimator.SetTrigger("SLOTIN");
                animBool = true;
                progressCheck = true;
                interactPanelBool = true;
            }

            if (input.InteractIsPressed == false && animBool == true)
            {
                PlayerController.state = PlayerController.State.free;
                tabletObject.SetActive(false);
                scannerAnimator.SetTrigger("Idle");
                animBool = false;
                progressCheck = false;
                progressSlider.value = 5;
                scannerNTime = 0.0f;
                cooldownTimer = cooldown;
                scannerLight.GetComponent<MeshRenderer>().material = scannerRedLightMat;
                interactPanelBool = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            scannerNTime = 0.0f;
            interactPanel.SetActive(false);
        }
    }
}
