using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public HumanoidLandInput input;
    public static bool GameIsPaused = false;//, dragMovement = true;
    public bool CurrentlyInOtherMenus = false;
    public GameObject pauseMenuUI, optionsMenuUI, controlsMenuUI;
    private string currentSceneName;
    public Transform cameraObject;
    public ButtonManager buttonManager;
    //public Button pauseButton;

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (optionsMenuUI.activeInHierarchy || controlsMenuUI.activeInHierarchy)
        {
            CurrentlyInOtherMenus = true;
        }
        else
        {
            CurrentlyInOtherMenus = false;
        }

        //pressing ESC can pause and unpause the game
        if(input.EscapeIsPressed == true && GameIsPaused == false && pauseMenuUI.activeInHierarchy == false) //pause game when ESC is pressed
        {
            Pause();
        }

        else if(input.EscapeIsPressed == true && GameIsPaused == true && pauseMenuUI.activeInHierarchy == true) //resume game when ESC is pressed 
        {
            Resume();

        }

        else if(input.EscapeIsPressed == false)
        {
            if (pauseMenuUI.activeInHierarchy == true)
            {
                GameIsPaused = true;
            }
            else
            {
                GameIsPaused = false;
            }
        }
    }

    public void Resume()
    {
        buttonManager.DisableMouseCursor();
        AudioManager.instance.PlaySound("buttonSound", cameraObject.position, false);
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        buttonManager.EnableMouseCursor();
        AudioManager.instance.PlaySound("buttonSound", cameraObject.position, false);
        pauseMenuUI.SetActive(true);
        if(CurrentlyInOtherMenus == true)
        {
            optionsMenuUI.SetActive(false);
            controlsMenuUI.SetActive(false);
        }
        Time.timeScale = 0f;
    }

    public void Options()
    {
        AudioManager.instance.PlaySound("buttonSound", cameraObject.position, false);
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResetScene()
    {
        Inventory.tabletObtained = false;
        Inventory.flashlightObtained = false;
        Inventory.gunObtained = false;

        Inventory.labKeyObtained = false;
        Inventory.lQKeyObtained = false;
        Inventory.generatorKeyObtained = false;

        Inventory.prisonFuzeObtained = false;
        Inventory.labFuzeObtained = false;
        Inventory.lQFuzeObtained = false;
        Inventory.generatorFuzeObtained = false;

        FirstParasite.Check = false;
        TVTriggerBehaviour.tvCheck = false;
        HandJumpScare.handSlapCheck = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Controls()
    {
        AudioManager.instance.PlaySound("buttonSound", cameraObject.position, false);
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
