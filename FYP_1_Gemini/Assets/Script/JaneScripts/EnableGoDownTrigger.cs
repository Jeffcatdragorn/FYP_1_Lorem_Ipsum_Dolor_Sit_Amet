using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGoDownTrigger : MonoBehaviour
{
    [SerializeField] private GameObject goDownTrigger;
    [SerializeField] private GameObject firstFloorAutoEDoorTrigger;

    private void OnTriggerStay(Collider other)
    {
        if (goDownTrigger.activeInHierarchy == false)
        {
            goDownTrigger.SetActive(true);
            firstFloorAutoEDoorTrigger.SetActive(false);
        }
    }
}
