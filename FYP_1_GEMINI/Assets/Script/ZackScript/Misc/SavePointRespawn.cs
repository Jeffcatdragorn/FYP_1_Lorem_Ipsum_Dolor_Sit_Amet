using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] GameObject savingIcon;
    [SerializeField] float fadeSpeed;
    [SerializeField] float duration;
    [SerializeField] GameObject lvl1Keycard, lvl2Keycard, lvl3Keycard, flashlight, tablet, gun, prisonFuse, labFuse, generalFuse, generatorFuse;
    private float durationTimer;
    public static int domeProgress;

    private void Awake()
    {
        if (Inventory.prisonFuzeObtained == false)
        {
            prisonFuse.SetActive(true);
        }
        else
        {
            prisonFuse.SetActive(false);
        }

        if (domeProgress > 0)
        {
            cutsceneManager.enabled = false;
            mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
            player.GetComponent<PlayerController>().enabled = true;
            mainCamAnimator.enabled = false;

            flashlight.SetActive(false);
            tablet.SetActive(false);

            if (thisDome == Dome.prison)
            {
                player.transform.position = transform.position;
            }
        }

        if (domeProgress > 1)
        {
            cutsceneManager.enabled = false;
            mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
            player.GetComponent<PlayerController>().enabled = true;
            mainCamAnimator.enabled = false;

            lvl1Keycard.SetActive(false);

            if (thisDome == Dome.lab)
            {
                player.transform.position = transform.position;
            }
        }

        if (domeProgress > 2)
        {
            cutsceneManager.enabled = false;
            mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
            player.GetComponent<PlayerController>().enabled = true;
            mainCamAnimator.enabled = false;

            gun.SetActive(false);
            labFuse.SetActive(false);
            lvl2Keycard.SetActive(false);

            if (thisDome == Dome.general)
            {
                player.transform.position = transform.position;
            }
        }

        if (domeProgress > 3)
        {
            cutsceneManager.enabled = false;
            mainCamAnimator.GetComponent<CinemachineBrain>().enabled = true;
            player.GetComponent<PlayerController>().enabled = true;
            mainCamAnimator.enabled = false;

            generalFuse.SetActive(false);
            lvl3Keycard.SetActive(false);

            if (thisDome == Dome.generator)
            {
                player.transform.position = transform.position;
            }
        }
    }

    private void Update()
    {
        if(durationTimer > 0)
        {
            savingIcon.SetActive(true);
            durationTimer -= Time.deltaTime;
        }

        else
        {
            savingIcon.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (thisDome == Dome.prison && !(domeProgress > 1))
            {
                domeProgress = 1;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            if (thisDome == Dome.lab && !(domeProgress > 2))
            {
                domeProgress = 2;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            if (thisDome == Dome.general && !(domeProgress > 3))
            {
                domeProgress = 3;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            if (thisDome == Dome.generator && !(domeProgress > 4))
            {
                domeProgress = 4;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            durationTimer = duration;
        }
    }

    public void Respawn()
    {
        FusePuzzleBehavior.fusePuzzleCompletion = 0;
        TeslaCoilBehaviour.teslaProgress = 0;

        if(domeProgress == 2)
        {
            Inventory.gunObtained = false;
            Inventory.labFuzeObtained = false;
            Inventory.lvl2KeyObtained = false;
        }


        if (domeProgress == 3)
        {
            Inventory.lQFuzeObtained = false;
            Inventory.lvl3KeyObtained = false;
        }

        if(domeProgress == 4)
        {
            Inventory.generatorFuzeObtained = false;
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
