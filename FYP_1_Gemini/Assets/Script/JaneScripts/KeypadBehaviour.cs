using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadBehaviour : MonoBehaviour
{
    InteractWithObjects input;
    public GameObject keycardObj;
    public static bool keycardInserted = false;

    private void Awake()
    {
        input = new InteractWithObjects();
        input.InteractWithObject.PutKeycardIn.performed += x => PutKeycardIn(); //set which actions to be done
    }

    private void Update()
    {
        Debug.Log("collectKeycard = " + KeycardBehaviour.collectedKeycard); //for testing only
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            input.InteractWithObject.Enable(); //enable the input (can use input)
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            input.InteractWithObject.Disable(); //disable the input (cannot use the input)
        }
    }

    private void PutKeycardIn()
    {
        if (KeycardBehaviour.collectedKeycard == true)
        {
            keycardInserted = true;
            keycardObj.SetActive(true);
            //other future logic once keycard is inserted can be applied below 
            
            Debug.Log("Keycard inserted to keypad!");
        }
    }
}
