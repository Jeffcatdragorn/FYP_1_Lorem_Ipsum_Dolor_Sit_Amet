using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingScript : MonoBehaviour
{
    public Slider loadingBar;
    public TextMeshProUGUI status;
    public TextMeshProUGUI progressNum;
    private float loadingBarSlider;
    private int randSpeed;
    private bool done;

    private void Start()
    {
        done = false;
        randSpeed = 0;
        loadingBarSlider = 0;
        status.text = "Downloading...";
    }
    void Update()
    {
        if (!done)
        {
            randSpeed = Random.Range(0,30);
            switch(randSpeed)
            {
                case 1:
                    loadingBarSlider++;
                    loadingBar.value = loadingBarSlider;
                    progressNum.text = loadingBar.value.ToString() + "%";
                    if (loadingBarSlider == 100) done = true;
                    break;
            }
        }
        else
        {
            status.text = "Download Complete!";
        }
    }
}
