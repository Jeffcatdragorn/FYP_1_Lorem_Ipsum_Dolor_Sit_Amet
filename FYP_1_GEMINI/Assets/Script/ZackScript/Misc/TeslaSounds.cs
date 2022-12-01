using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaSounds : MonoBehaviour
{
    [SerializeField] Transform teslaTransform;
    float timer;


    void Start()
    {
        AudioManager.instance.PlayMusic("teslaHumming", teslaTransform.position, true);
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            AudioManager.instance.PlaySound("teslaSparking", teslaTransform.position, true);
            timer = 3.0f;
        }
    }
}