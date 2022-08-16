using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandJumpScare : MonoBehaviour
{
    public Animator handAnimator;
    private bool handSlapSoundCheck;
    private static bool handSlapCheck;
    public GameObject lightObject;
    public float lightTime;
    private float lightCounter;
    public GameObject handPrint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "playerFront" && handSlapCheck == false)
        {
            handAnimator.SetTrigger("jumpscare");
            lightCounter = lightTime;
        }
    }

    private void Update()
    {
        if (handAnimator.GetCurrentAnimatorStateInfo(0).IsTag("jumpscare") == true && handSlapCheck == false)
        {
            AudioManager.instance.PlaySound("handSlap", transform.position, true);
            AudioManager.instance.PlaySound("jumpScareSound", transform.position, false);

            handPrint.SetActive(true);
            handSlapCheck = true;
        }

        if (lightCounter > 0)
        {
            lightObject.SetActive(true);
            lightCounter -= Time.deltaTime;
        }

        if (lightCounter <= 0)
        {
            lightObject.SetActive(false);
            lightCounter = 0.0f;
        }
    }
}