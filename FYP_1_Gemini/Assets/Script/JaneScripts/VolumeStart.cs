using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeStart : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetFloat("volume") == 0.0f )//first time launch game
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
            //Debug.Log("First time launch game");
        }
    }
}
