using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxBehaviour : MonoBehaviour
{
    InteractWithObjects input;
    public GameObject fuseObj;
    public GameObject lightBulb;
    //public DoorController doorController;
    public static bool fuseInserted = false;

    private void Awake()
    {
        input = new InteractWithObjects();
        input.InteractWithObject.PutFuseIn.performed += x => PutFuseIn(); //set which actions to be done
    }


    private void Update()
    {
        //Debug.Log("collectFuse = " + FuseBehaviour.collectedFuse); //for testing only
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

    private void PutFuseIn()
    {
        if(FuseBehaviour.collectedFuse == true)
        {
            fuseInserted = true;
            fuseObj.SetActive(true);
            //other future logic once fuse is inserted can be applied below 
            lightBulb.SetActive(true);
            Debug.Log("Fuse inserted to fuse box!");
        }
    }
}
