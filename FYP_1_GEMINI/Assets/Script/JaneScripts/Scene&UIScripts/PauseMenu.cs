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
    public GameObject pauseMenuUI, optionsMenuUI;
    //public Button pauseButton;

    // Update is called once per frame
    void Update()
    {
        if (optionsMenuUI.activeInHierarchy)
        {
            CurrentlyInOtherMenus = true;
        }
        else
        {
            CurrentlyInOtherMenus = false;
        }

        //pressing ESC can pause and unpause the game
        if(input.EscapeIsPressed == true && GameIsPaused == false && pauseMenuUI.activeInHierarchy == false)
        {
            Pause();
        }

        else if(input.EscapeIsPressed == true && GameIsPaused == true && pauseMenuUI.activeInHierarchy == true)
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

        Debug.Log("GameIsPaused:" + GameIsPaused);
    }

    public void Resume()
    {
        AudioManager.instance.PlaySound("buttonSound");
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //GameIsPaused = false;
        //pauseButton.gameObject.SetActive(true);

        //dragMovement = true;
        //Debug.Log("Game Resumed");
    }

    public void Pause()
    {
        AudioManager.instance.PlaySound("buttonSound");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //GameIsPaused = true;
        //pauseButton.gameObject.SetActive(false);

        //dragMovement = false;
        //Debug.Log("Game Paused");
    }
}
