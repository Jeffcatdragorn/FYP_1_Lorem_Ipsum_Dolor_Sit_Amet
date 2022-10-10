using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "MainMenu") //remember to add new scenes in the future
        {
            AudioManager.instance.PlayMusic("mainMenuMusic");
            //Debug.Log("Playing music");
        }

        //if(scene.name == "LevelSelectionScene" || scene.name == "Gallery" || scene.name == "SettingScene" || scene.name == "HandBookScene")
        //{
        //    AudioManager.instance.PlayMusic("basementMusic");
        //}
        
        //if(scene.name == "HawkMP5" || scene.name == "HawkPistol" || scene.name == "HawkShotgun")
        //{
        //    AudioManager.instance.PlayMusic("hawkMusic");
        //}

        //if (scene.name == "MorpheusMP5" || scene.name == "MorpheusPistol" || scene.name == "MorpheusShotgun")
        //{
        //    AudioManager.instance.PlayMusic("morpheusMusic");
        //}

        //if (scene.name == "Scyth3MP5" || scene.name == "Scyth3Pistol" || scene.name == "Scyth3Shotgun")
        //{
        //    AudioManager.instance.PlayMusic("scyth3Music");
        //}

        //if (scene.name == "XeAMP5" || scene.name == "XeAPistol" || scene.name == "XeAShotgun")
        //{
        //    AudioManager.instance.PlayMusic("xeaMusic");
        //}
    }
}
