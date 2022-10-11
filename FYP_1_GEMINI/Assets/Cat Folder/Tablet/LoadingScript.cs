using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class LoadingScript : MonoBehaviour
{
    public Slider loadingBar;
    public TextMeshProUGUI status;
    public TextMeshProUGUI progressNum;
    public HumanoidLandInput input;
    private float loadingBarSlider;
    private int randSpeed;
    private bool done, audioOn, load, trigger;
    public PlayerController playerController;

    public GameObject loadingScreen;
    public GameObject tablet;
    public GameObject inspectCam;

    private void Start()
    {
        done = false;
        audioOn = false;
        randSpeed = 0;
        loadingBarSlider = 0;
        status.text = "Downloading...";

    }
    void Update()
    {
        if (Inventory.labKeyObtained == true && inspectCam.activeInHierarchy == true)
        {
            if (input.FlashlightIsPressed)
            {
                trigger = true;
            }
        }

        if(trigger == true)
        {
            if (!load)
            {
                tablet.SetActive(true);
                loadingScreen.SetActive(true);
                load = true;
            }

            if (!audioOn)
            {
                AudioManager.instance.PlaySound("downloading", transform.position, false);
                audioOn = true;
            }

            if (!done)
            {
                //randSpeed = Random.Range(0, 23);
                //switch (randSpeed)
                //{
                //case 1:
                //loadingBarSlider ++ ; // for switch case
                playerController.enabled = false;
                loadingBarSlider += 11.5f * Time.deltaTime;
                loadingBar.value = loadingBarSlider;
                progressNum.text = loadingBar.value.ToString() + "%";
                if (loadingBarSlider > 100)
                {
                    done = true;
                }
                //if (loadingBarSlider == 100) done = true; // for switch case
                //break;
                //}
            }
            else
            {
                status.text = "Download Complete!";
                loadingScreen.SetActive(false);
                tablet.SetActive(false);
                playerController.enabled = true;
                this.gameObject.GetComponent<LoadingScript>().enabled = false;
            }
        }
    }
}