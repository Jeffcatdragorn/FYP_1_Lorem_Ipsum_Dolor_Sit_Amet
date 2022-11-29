using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class SavePointRespawn : MonoBehaviour
{
    public enum Dome
    {
        prison, lab, general, generator,
    }

    [SerializeField] Dome thisDome;
    [SerializeField] GameObject player;
    [SerializeField] Animator mainCamAnimator;
    [SerializeField] CutsceneManager cutsceneManager;
    public static int domeProgress;

    private void Awake()
    {
        if(domeProgress == 1)
        {
            cutsceneManager.enabled = false;
            mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
            player.GetComponent<PlayerController>().enabled = true;
            mainCamAnimator.enabled = false;

            if(thisDome == Dome.prison)
            {
                player.transform.position = transform.position;
            }
        }

        if (domeProgress == 2)
        {
            cutsceneManager.enabled = false;
            mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
            player.GetComponent<PlayerController>().enabled = true;
            mainCamAnimator.enabled = false;

            if (thisDome == Dome.lab)
            {
                player.transform.position = transform.position;
            }
        }

        if (domeProgress == 3)
        {
            cutsceneManager.enabled = false;
            mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
            player.GetComponent<PlayerController>().enabled = true;
            mainCamAnimator.enabled = false;

            if (thisDome == Dome.general)
            {
                player.transform.position = transform.position;
            }
        }

        if (domeProgress == 4)
        {
            cutsceneManager.enabled = false;
            mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
            player.GetComponent<PlayerController>().enabled = true;
            mainCamAnimator.enabled = false;

            if (thisDome == Dome.generator)
            {
                player.transform.position = transform.position;
            }
        }
    }

    private void Update()
    {
        Debug.Log(domeProgress);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (thisDome == Dome.prison && !(domeProgress > 1))
            {
                domeProgress = 1;
            }
            if (thisDome == Dome.lab && !(domeProgress > 2))
            {
                domeProgress = 2;
            }
            if (thisDome == Dome.general && !(domeProgress > 3))
            {
                domeProgress = 3;
            }
            if (thisDome == Dome.generator && !(domeProgress > 4))
            {
                domeProgress = 4;
            }
        }
    }


    public void Respawn()
    {
        FusePuzzleBehavior.fusePuzzleCompletion = 0;
        TeslaCoilBehaviour.teslaProgress = 0;

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
