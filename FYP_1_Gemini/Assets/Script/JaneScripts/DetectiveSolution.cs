using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveSolution : MonoBehaviour
{
    InteractWithObjects input;
    public GameObject door;
    private int inputCount = 0;
    private bool inputChecker;
    public Animator doorAnimator;

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
        //currentDoorPos = door.transform.position;
        doorAnimator.enabled = false;

        if (inputCount == 7) //if press 7 times already then stop opening the door
        {
            inputCount = 7;
            door.transform.position = new Vector3(0.0f, 0.0f, 7.0f);
            //Destroy(door);
        }
        else
        {
            inputCount++;
            door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z + 1.0f);
            Debug.Log("door.transform.position = " + door.transform.position);
        }
        
        Debug.Log("OpenDoorWithShooting ");
    }
}
