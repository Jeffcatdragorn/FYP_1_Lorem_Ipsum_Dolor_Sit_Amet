using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOutBehaviour : MonoBehaviour
{
    [Header("Prison")]
    [SerializeField] GameObject prisonLights;
    private bool prisonDome = false;

    [Header("Lab")]
    [SerializeField] GameObject labLights;
    [SerializeField] GameObject[] labDoors;
    [SerializeField] GameObject[] labSwarms;
    private bool labDome = false;

    [Header("General")]
    [SerializeField] GameObject generalLights;
    [SerializeField] GameObject[] generalDoors;
    private bool generalDome = false;

    void Update()
    {
        if(Inventory.prisonFuzeObtained == true && prisonDome == false)
        {
            prisonLights.SetActive(false);
            prisonDome = true;
        }

        if (Inventory.labFuzeObtained == true && labDome == false)
        {
            labLights.SetActive(false);
            labDome = true;
        }

        if (Inventory.lQFuzeObtained == true && generalDome == false)
        {
            generalLights.SetActive(false);
            generalDome = true;
        }
    }
}
