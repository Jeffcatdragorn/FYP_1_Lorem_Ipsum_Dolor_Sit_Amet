using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareQTE : MonoBehaviour
{
    [SerializeField] private HumanoidLandInput input;
    [SerializeField] private Animator deadBodyAnimator;
    private bool canTrigger = false;

    private void Update()
    {
        if(canTrigger == true)
        {
            if(input.ShootIsPressed == true)
            {
                deadBodyAnimator.SetTrigger("die");
                gameObject.transform.parent.gameObject.SetActive(false);
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
