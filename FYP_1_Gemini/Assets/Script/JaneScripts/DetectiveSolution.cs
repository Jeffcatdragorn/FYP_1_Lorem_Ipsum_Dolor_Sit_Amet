using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveSolution : MonoBehaviour
{
    InteractWithObjects input;
    private int inputCount = 0;
    private bool inputChecker;

    private void Awake()
    {
        input = new InteractWithObjects();
        input.DetectivePath.SpamFToOpen.performed += x => OpenDoorWithShooting(); //set which actions to be done
    }

    #region OnEnable & OnDisable (For input)

    private void OnEnable()
    {
        input.DetectivePath.Enable();
    }

    private void OnDisable()
    {
        input.DetectivePath.Disable();
    }

    #endregion

    private void Update()
    {
        Debug.Log("inputCount = " + inputCount);
    }

    public void OpenDoorWithShooting() //grappling door & pulling it open
    {
        inputCount++;

        if (inputCount == 5)
        {
           
        }

       
        Debug.Log("OpenDoorWithShooting ");
    }
}
