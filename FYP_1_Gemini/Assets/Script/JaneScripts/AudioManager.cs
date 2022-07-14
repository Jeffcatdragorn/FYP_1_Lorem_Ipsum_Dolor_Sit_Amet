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

    public AudioClip mainMenuMusic; //bgm

    public AudioClip buttonSound, doorOpening, walkingFootstep, tabletOning, revolverReload, revolverShoot, itemPickUp; //sfx

    private GameObject currentMusicObject;

    public GameObject soundObject, SFXButton;

    public GameObject musicObject, MUSICButton;

    public static bool SFXCheck = true, MUSICCheck = true;

    //private GameObject check;

    GameObject[] obj1, obj2;


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

    public void PlaySound(string soundName, Vector3 spawnPosition)
    {
        if(SFXCheck == true)
        {
            switch (soundName)
            {
                case "buttonSound":
                    SoundObjectCreate(buttonSound, spawnPosition);
                    break;
                case "doorOpening":
                    SoundObjectCreate(doorOpening, spawnPosition); 
                    break;
                case "walkingFootstep":
                    SoundObjectCreate(walkingFootstep, spawnPosition); 
                    break;
                case "tabletOning":
                    SoundObjectCreate(tabletOning, spawnPosition);
                    break;
                case "revolverReload":
                    SoundObjectCreate(revolverReload, spawnPosition);
                    break;
                case "revolverShoot":
                    SoundObjectCreate(revolverShoot, spawnPosition);
                    break;
                case "itemPickUp":
                    SoundObjectCreate(itemPickUp, spawnPosition);
                    break;
                default:
                    break;
            }
        }
    }

    void SoundObjectCreate(AudioClip clip, Vector3 spawnPosition)
    {
        GameObject newObject = Instantiate(soundObject, spawnPosition, Quaternion.identity);

        newObject.GetComponent<AudioSource>().clip = clip;

        newObject.GetComponent<AudioSource>().Play();
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
