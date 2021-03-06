using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardScanner : MonoBehaviour
{
    InteractWithObjects input;
    //public GameObject keycardObj;
    //public static bool keycardScanned = false;
    public bool keycardScanned = false;

    public Inventory inventory;// List<Item> items = new List<Item>();

    private void Awake()
    {
        input = new InteractWithObjects();
        input.InteractWithObject.ScanKeycard.performed += x => ScanKeycard(); //set which actions to be done
    }

    private void Update()
    {
        //Debug.Log("collectKeycard = " + KeycardBehaviour.collectedKeycard); //for testing only
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

    private void ScanKeycard()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.items[i].name == "Keycard01")
            {
                keycardScanned = true;
                Debug.Log("Keycard scanned!");
            }
            else
            {
                Debug.Log("Keycard not found, can't scan!");
            }
        }
    }
}
