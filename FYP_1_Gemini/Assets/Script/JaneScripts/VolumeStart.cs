using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeStart : MonoBehaviour
{
    static bool notFirstTimeLaunchGame;

    private void Awake()
    {
        if (notFirstTimeLaunchGame == false) //first time launch game
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
            notFirstTimeLaunchGame = true;
            //Debug.Log("First time launch game");
        }
    }
}
