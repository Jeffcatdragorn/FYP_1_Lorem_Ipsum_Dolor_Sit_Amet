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
    private float loadingBarSlider;
    private int randSpeed;
    private bool done, audioOn;

    public GameObject key;
    public GameObject button;

    private void Start()
    {
        done = false;
        audioOn = false;
        randSpeed = 0;
        loadingBarSlider = 0;
        status.text = "Downloading...";
        button.SetActive(false);

    }
    void Update()
    {
        if (key == null)
        {
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
                loadingBarSlider += 11.5f * Time.deltaTime;
                loadingBar.value = loadingBarSlider;
                progressNum.text = loadingBar.value.ToString() + "%";
                Debug.Log(loadingBarSlider + " <-");
                if (loadingBarSlider > 100) done = true;
                //if (loadingBarSlider == 100) done = true; // for switch case
                //break;
                //}
            }
            else
            {
                status.text = "Download Complete!";
                button.SetActive(true); 
            }
        }
    }
}
