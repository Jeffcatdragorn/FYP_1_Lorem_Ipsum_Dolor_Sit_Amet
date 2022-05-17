using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardBehaviour : MonoBehaviour
{
    public static bool collectedKeycard = false;
    InteractWithObjects input;

    private void Awake()
    {
        input = new InteractWithObjects();
        input.InteractWithObject.CollectKeycard.performed += x => PickUpKeycard(); //set which actions to be done
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

    private void PickUpKeycard()
    {
        collectedKeycard = true;
        gameObject.SetActive(false);
    }
}
