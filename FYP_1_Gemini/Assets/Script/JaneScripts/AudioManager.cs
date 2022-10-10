using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
    }

    //public AudioClip ;

    public AudioClip mainMenuMusic, pressureAmbienceMusic; //bgm

    public AudioClip buttonSound, doorOpening, walkingFootstep, tabletOning, revolverReload, revolverShoot, itemPickUp, jumpScareSound, alarmSound,
                     normalMetalFootstep1, normalMetalFootstep2, normalMetalFootstep3, normalMetalFootstep4, ventCoverFalling, ventCrawling, tvAudio, handSlap,
                     screeching, headCrabScreech, bringUpTablet, gunCharging, playerDeath, downloading, exposedFuse, flashlightOff, flashlightOn, labJumpscare,
                        lowBatteryError, ObjComplete, tabletIn, tabletOut, swarmAttack, labJumpScareSwarm; //sfx

    private GameObject currentMusicObject;

    public GameObject soundObject, SFXButton;

    public GameObject musicObject, MUSICButton;

    public static bool SFXCheck = true, MUSICCheck = true;

    //private GameObject check;

    GameObject[] obj1, obj2;
    private GameObject footstepObject;

    private void Update()
    {
        obj1 = GameObject.FindGameObjectsWithTag("music");
        for (int i = 0; i < obj1.Length; i++)
        {
            if (obj1[i] != null && MUSICCheck == true)
            {
                //DontDestroyOnLoad(obj1[i]);
                obj1[i].GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
            }

            if (obj1[i] != null && MUSICCheck == false)
            {
                //DontDestroyOnLoad(obj1[i]);
                obj1[i].GetComponent<AudioSource>().volume = 0.0f;
            }
        }

        obj2 = GameObject.FindGameObjectsWithTag("sound");
        for (int i = 0; i < obj2.Length; i++)
        {
            if (obj2[i] != null)
            {
                obj2[i].GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume"); ;//PlayerPrefs.GetFloat("volume");
            }
        }

        if(SFXCheck == false)
        {
            SFXButton.transform.Find("ON").GetComponent<Button>().interactable = true;
            SFXButton.transform.Find("OFF").GetComponent<Button>().interactable = false;
        }

        else if (SFXCheck == true)
        {
            SFXButton.transform.Find("ON").GetComponent<Button>().interactable = false;
            SFXButton.transform.Find("OFF").GetComponent<Button>().interactable = true;
        }

        if (MUSICCheck == false)
        {
            MUSICButton.transform.Find("ON").GetComponent<Button>().interactable = true;
            MUSICButton.transform.Find("OFF").GetComponent<Button>().interactable = false;
        }

        else if (MUSICCheck == true)
        {
            MUSICButton.transform.Find("ON").GetComponent<Button>().interactable = false;
            MUSICButton.transform.Find("OFF").GetComponent<Button>().interactable = true;
        }
    }

    public void PlayMusic(string musicName)
    {
        if(MUSICCheck == true)
        {
            switch (musicName)
            {
                case "mainMenuMusic":
                    MusicObjectCreate(mainMenuMusic);
                    break;
                case "pressureAmbienceMusic":
                    MusicObjectCreate(pressureAmbienceMusic);
                    break;
                default:
                    break;
            }
        }
    }

    void MusicObjectCreate(AudioClip clip)
    {
        //if (currentMusicObject != null)
        //{
        //    Destroy(currentMusicObject);
        //}

        currentMusicObject = Instantiate(musicObject);

        currentMusicObject.GetComponent<AudioSource>().clip = clip;

        currentMusicObject.GetComponent<AudioSource>().loop = true;

        currentMusicObject.GetComponent<AudioSource>().Play();
    }

    public void PlaySound(string soundName, Vector3 spawnPosition, bool is3D)
    {
        if(SFXCheck == true)
        {
            switch (soundName)
            {
                case "buttonSound":
                    SoundObjectCreate(buttonSound, spawnPosition, is3D);
                    break;
                case "doorOpening":
                    SoundObjectCreate(doorOpening, spawnPosition, is3D); 
                    break;
                case "walkingFootstep":
                    SoundObjectCreate(walkingFootstep, spawnPosition, is3D); 
                    break;
                case "tabletOning":
                    SoundObjectCreate(tabletOning, spawnPosition, is3D);
                    break;
                case "revolverReload":
                    SoundObjectCreate(revolverReload, spawnPosition, is3D);
                    break;
                case "revolverShoot":
                    SoundObjectCreate(revolverShoot, spawnPosition, is3D);
                    break;
                case "itemPickUp":
                    SoundObjectCreate(itemPickUp, spawnPosition, is3D);
                    break;
                case "jumpScareSound":
                    SoundObjectCreate(jumpScareSound, spawnPosition, is3D);
                    break; 
                case "alarmSound":
                    SoundObjectCreate(alarmSound, spawnPosition, is3D);
                    break;
                case "ventCoverFalling":
                    SoundObjectCreate(ventCoverFalling, spawnPosition, is3D);
                    break;
                case "ventCrawling":
                    SoundObjectCreate(ventCrawling, spawnPosition, is3D);
                    break;                
                case "tvAudio":
                    SoundObjectCreate(tvAudio, spawnPosition, is3D);
                    break;                
                case "handSlap":
                    SoundObjectCreate(handSlap, spawnPosition, is3D);
                    break;         
                case "screeching":
                    SoundObjectCreate(screeching, spawnPosition, is3D);
                    break;
                case "bringUpTablet":
                    SoundObjectCreate(bringUpTablet, spawnPosition, is3D);
                    break;
                case "gunCharging":
                    SoundObjectCreate(gunCharging, spawnPosition, is3D);
                    break;
                case "playerDeath":
                    SoundObjectCreate(playerDeath, spawnPosition, is3D);
                    break;
                case "downloading":
                    SoundObjectCreate(downloading, spawnPosition, is3D);
                    break;
                case "exposedFuse":
                    SoundObjectCreate(exposedFuse, spawnPosition, is3D);
                    break;
                case "flashlightOff":
                    SoundObjectCreate(flashlightOff, spawnPosition, is3D);
                    break;
                case "flashlightOn":
                    SoundObjectCreate(flashlightOn, spawnPosition, is3D);
                    break;
                case "labJumpscare":
                    SoundObjectCreate(labJumpscare, spawnPosition, is3D);
                    break;
                case "lowBatteryError":
                    SoundObjectCreate(lowBatteryError, spawnPosition, is3D);
                    break;
                case "ObjComplete":
                    SoundObjectCreate(ObjComplete, spawnPosition, is3D);
                    break;
                case "tabletIn":
                    SoundObjectCreate(tabletIn, spawnPosition, is3D);
                    break;
                case "tabletOut":
                    SoundObjectCreate(tabletOut, spawnPosition, is3D);
                    break;
                case "swarmAttack":
                    SoundObjectCreate(swarmAttack, spawnPosition, is3D);
                    break;
                case "labJumpScareSwarm":
                    SoundObjectCreate(labJumpScareSwarm, spawnPosition, is3D);
                    break;
                default:
                    break;
            }
        }
    }

    public void PlaySoundParent(string soundName, GameObject spawnParent, bool is3D)
    {
        if (SFXCheck == true)
        {
            switch (soundName)
            {
                case "normalMetalFootstep1":
                    SoundObjectCreateParent(normalMetalFootstep1, spawnParent, is3D);
                    break;
                case "normalMetalFootstep2":
                    SoundObjectCreateParent(normalMetalFootstep2, spawnParent, is3D);
                    break;
                case "normalMetalFootstep3":
                    SoundObjectCreateParent(normalMetalFootstep3, spawnParent, is3D);
                    break;
                case "normalMetalFootstep4":
                    SoundObjectCreateParent(normalMetalFootstep4, spawnParent, is3D);
                    break;
                case "screeching":
                    SoundObjectCreateParent(screeching, spawnParent, is3D);
                    break;
                case "headCrabScreech":
                    SoundObjectCreateParent(headCrabScreech, spawnParent, is3D);
                    break;
                default:
                    break;
            }
        }
    }

    void SoundObjectCreate(AudioClip clip, Vector3 spawnPosition, bool is3D)
    {
        GameObject newObject = Instantiate(soundObject, spawnPosition, Quaternion.identity);

        if(is3D == true)
        {
            newObject.GetComponent<AudioSource>().spatialBlend = 1;
        }

        else
        {
            newObject.GetComponent<AudioSource>().spatialBlend = 0;
        }

        if(clip == alarmSound)
        {
            newObject.GetComponent<AudioSource>().loop = true;
        }

        if(clip == ventCrawling)
        {
            newObject.GetComponent<AudioSource>().priority = 200;
        }

        if (clip == tvAudio)
        {
            newObject.GetComponent<AudioSource>().minDistance = 5.0f;
        }

        newObject.GetComponent<AudioSource>().clip = clip;

        newObject.GetComponent<AudioSource>().Play();
    }

    void SoundObjectCreateParent(AudioClip clip, GameObject spawnParent, bool is3D)
    {

        footstepObject = Instantiate(soundObject);
        footstepObject.transform.parent = spawnParent.transform;
        footstepObject.transform.position = spawnParent.transform.position;
        footstepObject.transform.rotation = spawnParent.transform.rotation;

        if (is3D == true)
        {
            footstepObject.GetComponent<AudioSource>().spatialBlend = 1;
        }

        else
        {
            footstepObject.GetComponent<AudioSource>().spatialBlend = 0;
        }

        footstepObject.GetComponent<AudioSource>().clip = clip;

        footstepObject.GetComponent<AudioSource>().Play();
    }

    public void SFXOff()
    {
        SFXCheck = false;
        obj2 = GameObject.FindGameObjectsWithTag("sound");
        for (int i = 0; i < obj2.Length; i++)
        {
            if (obj2[i] != null)
            {
                Destroy(obj2[i]);
            }
        }
    }

    public void SFXOn()
    {
        SFXCheck = true;
    }

    public void MUSICOff()
    {
        MUSICCheck = false;
        Debug.Log("musicoff");
    }

    public void MUSICOn()
    {
        MUSICCheck = true;
        Debug.Log("musicoff");
    }

    void PauseAll()
    {
        obj1 = GameObject.FindGameObjectsWithTag("music");
        for (int i = 0; i < obj1.Length; i++)
        {
            if (obj1[i] != null)
            {
                obj1[i].GetComponent<AudioSource>().Pause();
            }
        }

        obj2 = GameObject.FindGameObjectsWithTag("sound");
        for (int i = 0; i < obj2.Length; i++)
        {
            if (obj2[i] != null)
            {
                obj2[i].GetComponent<AudioSource>().Pause();
            }
        }
    }
}
