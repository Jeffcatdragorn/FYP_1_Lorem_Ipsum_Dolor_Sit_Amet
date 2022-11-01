using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GunJumpScare : MonoBehaviour
{
    [SerializeField] private GameObject inspectCam;
    [SerializeField] private GameObject deadBody;
    //[SerializeField] private GameObject deadBodyStand;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cameraFollow;
    [SerializeField] private GameObject swarm;
    [SerializeField] private GameObject gunTutorialPanel;
    [SerializeField] private Animator mainCamAnimator;
    //[SerializeField] private Animator deadBodyAnimator;
    [SerializeField] private HumanoidLandInput input;
    //[SerializeField] private GameObject QTE;
    //[SerializeField] private GameObject deadPanel;
    private bool inspectOff = false;
    private bool triggerOnce = false;
    private bool trigger = false;

    private AnimatorStateInfo animCamStateInfo;
    private float camNTime;
    //private AnimatorStateInfo animBodyStateInfo;
    //private float bodyNTime;
    //private AnimatorStateInfo animBodyDeadStateInfo;
    //private float bodyDeadNTime;


    void Update()
    {
        if(inspectCam.activeInHierarchy == true && Inventory.gunObtained == true && triggerOnce == false)
        {
            player.transform.localPosition = new Vector3(-461.480011f, -12.9399996f, 219.160004f);
            player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            cameraFollow.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;



            if (input.FlashlightIsPressed == true)
            {
                inspectOff = true;
                triggerOnce = true;
            }
        }

        if (inspectOff == true)
        {
            deadBody.SetActive(false);
            swarm.SetActive(true);
            //swarm.GetComponent<SwarmStates>().enabled = false;

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
            AudioManager.instance.PlaySound("labJumpscare", player.transform.position, false);
            //AudioManager.instance.PlaySound("labJumpScareSwarm", player.transform.position, false);
            gunTutorialPanel.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.transform.eulerAngles = new Vector3(0f, -180f, 0f);
            cameraFollow.transform.eulerAngles = new Vector3(0f, -180f, 0f);
            //deadBodyAnimator.SetTrigger("jump");
            trigger = true;
        }

        //if (deadBodyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        //{
        //    animBodyStateInfo = deadBodyAnimator.GetCurrentAnimatorStateInfo(0);
        //    bodyNTime = animBodyStateInfo.normalizedTime;
        //}

        //if (bodyNTime > 1.0f && trigger2 == false)
        //{
        //    deadPanel.SetActive(true);
        //    AudioManager.instance.PlaySound("playerDeath", player.transform.position, false);
        //    trigger2 = true;
        //}
        
        //if (bodyNTime > 0.2f && trigger3 == false)
        //{
        //    QTE.SetActive(true);
        //    trigger3 = true;
        //}

        //if (deadBodyAnimator.GetCurrentAnimatorStateInfo(0).IsName("die"))
        //{
        //    animBodyDeadStateInfo = mainCamAnimator.GetCurrentAnimatorStateInfo(0);
        //    bodyDeadNTime = animBodyDeadStateInfo.normalizedTime;
        //}

        //if (bodyDeadNTime > 1.0f && trigger4 == false)
        //{
        //    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //    player.GetComponent<PlayerController>().enabled = true;
        //    this.gameObject.GetComponent<GunJumpScare>().enabled = false;
        //    trigger4 = true;
        //}
    }

    public void GunTutorialOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //swarm.GetComponent<SwarmStates>().enabled = true;
        Time.timeScale = 1;

        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
        mainCamAnimator.enabled = false;
        gunTutorialPanel.SetActive(false);
    }
}
