using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class JumpScareQTE : MonoBehaviour
{
    [SerializeField] private HumanoidLandInput input;
    [SerializeField] private Animator deadBodyAnimator;
    [SerializeField] private Animator mainCamAnimator;
    [SerializeField] private GameObject player;
    private bool canTrigger = false;

    private void Update()
    {
        if(canTrigger == true)
        {
            if(input.ShootIsPressed == true)
            {
                deadBodyAnimator.SetTrigger("die");
                gameObject.transform.parent.gameObject.SetActive(false);
                mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
                mainCamAnimator.enabled = false;
                player.GetComponent<PlayerController>().enabled = true;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "QTE")
        {
            canTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "QTE")
        {
            canTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "QTE")
        {
            canTrigger = false;
        }
    }
}
