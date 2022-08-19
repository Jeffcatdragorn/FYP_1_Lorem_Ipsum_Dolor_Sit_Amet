using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Transform cameraObject;
    //public static bool usedCom;

    //public static ButtonManager instance;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }

    //    if (instance != null)
    //    {
    //        Destroy(gameObject); //destroy in another scene
    //        return;
    //    }

    //    DontDestroyOnLoad(gameObject);
    //}

    public void PlayButtonSound()
    {
        AudioManager.instance.PlaySound("buttonSound", cameraObject.position, false);
    }

    //public void Play()
    //{
    //    PlayButtonSound();
    //    //Debug.Log("Loading to Level Selection Scene...");
    //    //usedcom = false;
    //    //PlayerPrefs.SetInt("spawnInfrontTerminal", 1);
    //    //PlayerPrefs.SetInt("usedCom", 0); // 0 is false
    //    Time.timeScale = 1f;
    //    Loader.Load(Loader.Scene.PrototypeScene);
    //}

    public void ShootingRange()
    {
        PlayButtonSound();
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.ShootingRange);
    }

    public void PrototypeScene()
    {
        PlayButtonSound();
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.PrototypeScene);
    }

    public void FloatingPuzzleScene()
    {
        PlayButtonSound();
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.FloatingLevel);
    }

    public void MazeScene()
    {
        PlayButtonSound();
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.Maze);
    }

    public void PrisonScene()
    {
        PlayButtonSound();
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.PrisonDomeLayout);
    }

    public void Exit()
    {
        PlayButtonSound();
        //Debug.Log("Exiting Game...");
        Application.Quit();
    }

    public void MainMenu()
    {
        PlayButtonSound();
        //Debug.Log("Loading to Main Menu...");
        Inventory.tabletObtained = false;
        Inventory.flashlightObtained = false;
        FirstParasite.Check = false;
        TVTriggerBehaviour.tvCheck = false;
        HandJumpScare.handSlapCheck = false;
        Time.timeScale = 1f;
        //PauseMenu.GameIsPaused = false;
        Loader.Load(Loader.Scene.MainMenu);
    }

    public void EnableMouseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void DisableMouseCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}