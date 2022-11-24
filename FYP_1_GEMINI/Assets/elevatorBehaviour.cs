using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class elevatorBehaviour : MonoBehaviour
{
    public TextMeshPro text;
    public Slider slider;
    private float time;
    private int depth;
    public bool usingSlider;
    void Start()
    {
        //depth = 10000;
    }

    void Update()
    {
        if (usingSlider)
        {
            depth = (int)slider.value;
            text.text = depth.ToString("n0");
            if (depth <= 0)
            {
                depth = 0;
            }
        }
        else
        {
            time = time + ( Time.deltaTime/ 3);
            depth -= (int)time;
            if (depth <= 0)
            {
                depth = 0;
            }
            text.text = depth.ToString("n0");
        }

    }
}
