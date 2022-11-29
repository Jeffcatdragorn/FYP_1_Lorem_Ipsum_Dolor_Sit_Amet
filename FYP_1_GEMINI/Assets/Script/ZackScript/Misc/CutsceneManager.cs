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
    [SerializeField] private GameObject tutorialPanel;
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
        if(!(SavePointRespawn.domeProgress > 0))
            mainCamAnimator.SetTrigger("openingScene");
    }

    private void Update()
    {
        if (particleBool == false)
        {
            animCamStateInfo = mainCamAnimator.GetCurrentAnimatorStateInfo(0);
            camNTime = animCamStateInfo.normalizedTime;

            if (camNTime > 1.0f)
            {
                if (doorBool == false)
                {

                    tutorialPanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    doorBool = true;
                }
            }
            //if (doorNTime > 1.0f)
            //{

            //}
        }
    }

    public void endCutscene()
    {
        mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
        mainCamAnimator.enabled = false;
        player.GetComponent<PlayerController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (particleBool == false)
        {
            cellDoorAnimator.SetTrigger("openDoor");
            //animDoorStateInfo = cellDoorAnimator.GetCurrentAnimatorStateInfo(0);
            //doorNTime = animDoorStateInfo.normalizedTime;
            sparkParticle1.Play();
            sparkParticle2.Play();
            particleBool = true;
        }
    }
}
