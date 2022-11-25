using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGoUpTrigger : MonoBehaviour
{
    [SerializeField] private GameObject goUpTrigger;
    [SerializeField] private GameObject groundFloorAutoEDoorTrigger;

    private void OnTriggerStay(Collider other)
   {
        if(goUpTrigger.activeInHierarchy == false)
        {
            goUpTrigger.SetActive(true);
            groundFloorAutoEDoorTrigger.SetActive(false);
        }
   }
}
