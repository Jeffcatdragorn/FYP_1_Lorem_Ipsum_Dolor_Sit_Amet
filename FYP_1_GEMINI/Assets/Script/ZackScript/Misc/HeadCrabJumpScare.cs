using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class HeadCrabJumpScare : MonoBehaviour
{
    [SerializeField] private Animator headCrabAnimator;
    [SerializeField] private Animator mainCamAnimator;
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private GameObject headCrab;
    [SerializeField] private GameObject cameraFollow;
    private GameObject player;
    private bool triggered = false;
    private bool check = false;
    private bool check2 = false;
    private bool check3 = false;
    private AnimatorStateInfo animDoorStateInfo;
    private float doorNTime;
    private AnimatorStateInfo animCamStateInfo;
    private float camNTime;

    private void Update()
    {
        if(triggered == true)
        {
            if (doorAnimator.GetCurrentAnimatorStateInfo(0).IsName("DomeGateOpen"))
            {
                animDoorStateInfo = doorAnimator.GetCurrentAnimatorStateInfo(0);
                doorNTime = animDoorStateInfo.normalizedTime;
            }

            if (doorNTime > 0.5f && check == false)
            {
                headCrabAnimator.SetTrigger("jump");
                mainCamAnimator.GetComponent<CinemachineBrain>().enabled = false;
                mainCamAnimator.enabled = true;
                mainCamAnimator.SetTrigger("headCrabJump");
                check = true;
            }
        }

        if(check == true)
        {
            if (mainCamAnimator.GetCurrentAnimatorStateInfo(0).IsName("headCrabJumpScare"))
            {
                animCamStateInfo = mainCamAnimator.GetCurrentAnimatorStateInfo(0);
                camNTime = animCamStateInfo.normalizedTime;
            }

            if (camNTime > 0.16f && check3 == false)
            {
                AudioManager.instance.PlaySound("labJumpscare", player.transform.position, false);
                AudioManager.instance.PlaySoundParent("headCrabScreech", headCrabAnimator.gameObject, true);
                check3 = true;
            }

            if (camNTime > 1f && check2 == false)
            {
                mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
                mainCamAnimator.enabled = false;
                player.GetComponent<PlayerController>().enabled = true;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                check2 = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && triggered == false)
        {
            other.gameObject.transform.localPosition = new Vector3(-389.100006f, -12.9399996f, 93.6999969f);
            other.gameObject.transform.eulerAngles = new Vector3(0f, -90f, 0f);
            cameraFollow.transform.eulerAngles = new Vector3(0f, -90f, 0f);
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            player = other.gameObject;
            triggered = true;
        }
    }
}
