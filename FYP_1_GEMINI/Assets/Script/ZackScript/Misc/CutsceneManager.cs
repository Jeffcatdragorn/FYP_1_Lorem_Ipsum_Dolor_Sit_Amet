using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject mainCamObj;
    [SerializeField] private Animator mainCamAnimator;
    [SerializeField] private Animator cellDoorAnimator;
    [SerializeField] private GameObject player;
    [SerializeField] private ParticleSystem sparkParticle1;
    [SerializeField] private ParticleSystem sparkParticle2;
    private AnimatorStateInfo animCamStateInfo;
    private AnimatorStateInfo animDoorStateInfo;
    private float camNTime;
    private float doorNTime;
    private bool doorBool = false;
    private bool particleBool = false;

    private void Start()
    {
        mainCamAnimator.SetTrigger("openingScene");
    }

    private void Update()
    {
        animCamStateInfo = mainCamAnimator.GetCurrentAnimatorStateInfo(0);
        camNTime = animCamStateInfo.normalizedTime;

        if (camNTime > 1.0f)
        {
            if(doorBool == false)
            {
                cellDoorAnimator.SetTrigger("openDoor");
                animDoorStateInfo = cellDoorAnimator.GetCurrentAnimatorStateInfo(0);
                doorNTime = animDoorStateInfo.normalizedTime;
                doorBool = true;
            }
        }
        if (doorNTime > 1.0f)
        {
            mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
            mainCamAnimator.enabled = false;
            player.GetComponent<PlayerController>().enabled = true;
            if(particleBool == false)
            {
                sparkParticle1.Play();
                sparkParticle2.Play();
                particleBool = true;
            }
        }
    }
}
