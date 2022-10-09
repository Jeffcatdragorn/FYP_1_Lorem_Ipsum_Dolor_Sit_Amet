using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GunJumpScare : MonoBehaviour
{
    [SerializeField] private GameObject inspectCam;
    [SerializeField] private GameObject deadBody;
    [SerializeField] private GameObject deadBodyStand;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator mainCamAnimator;
    [SerializeField] private Animator deadBodyAnimator;
    [SerializeField] private HumanoidLandInput input;
    [SerializeField] private GameObject QTE;
    [SerializeField] private GameObject deadPanel;
    private bool inspectOff = false;
    private bool trigger = false;
    private bool trigger2 = false;
    private bool trigger3 = false;
    private AnimatorStateInfo animCamStateInfo;
    private float camNTime;
    private AnimatorStateInfo animBodyStateInfo;
    private float bodyNTime;

    void Update()
    {
        if(inspectCam.activeInHierarchy == true && Inventory.gunObtained == true)
        {
            player.transform.localPosition = new Vector3(-461.480011f, -12.9399996f, 219.160004f);
            player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

            if (input.FlashlightIsPressed == true)
            {
                inspectOff = true;
            }
        }

        if(inspectOff == true)
        {
            deadBody.SetActive(false);
            deadBodyStand.SetActive(true);
            mainCamAnimator.GetComponent<CinemachineBrain>().enabled = false;
            mainCamAnimator.enabled = true;
            mainCamAnimator.SetTrigger("gunJumpScare");
            inspectOff = false;
        }

        if (mainCamAnimator.GetCurrentAnimatorStateInfo(0).IsName("gunJumpScare"))
        {
            animCamStateInfo = mainCamAnimator.GetCurrentAnimatorStateInfo(0);
            camNTime = animCamStateInfo.normalizedTime;
        }

        if(camNTime > 1.0f && trigger == false)
        {
            deadBodyAnimator.SetTrigger("jump");
            trigger = true;
        }

        if (deadBodyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            animBodyStateInfo = deadBodyAnimator.GetCurrentAnimatorStateInfo(0);
            bodyNTime = animBodyStateInfo.normalizedTime;
        }

        if (bodyNTime > 1.0f && trigger2 == false)
        {
            deadPanel.SetActive(true);
            trigger2 = true;
        }
        
        if (bodyNTime > 0.2f && trigger3 == false)
        {
            QTE.SetActive(true);
            trigger3 = true;
        }
    }
}