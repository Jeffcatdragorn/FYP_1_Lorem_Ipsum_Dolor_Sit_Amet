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
    [SerializeField] GameObject[] labSwarmsDeactive;
    [SerializeField] GameObject[] labSwarms;
    private bool labDome = false;

    [Header("General")]
    [SerializeField] GameObject generalLights;
    [SerializeField] GameObject[] generalDoors;
    private bool generalDome = false;

    void Update()
    {
        if (Inventory.prisonFuzeObtained == true && prisonDome == false)
        {
            prisonLights.SetActive(false);
            prisonDome = true;
        }

        if (Inventory.labFuzeObtained == true && labDome == false)
        {
            bool doorDone = false;
            bool swarmDeactiveDone = false;
            bool swarmDone = false;

            labLights.SetActive(false);

            for (int i = 0; i < labDoors.Length; i++)
            {
                labDoors[i].SetActive(false);

                if (i == labDoors.Length - 1)
                {
                    doorDone = true;
                }
            }

            for (int i = 0; i < labSwarms.Length; i++)
            {
                labSwarms[i].SetActive(false);

                if (i == labSwarms.Length - 1)
                {
                    swarmDone = true;
                }
            }

            for (int i = 0; i < labSwarmsDeactive.Length; i++)
            {
                labSwarmsDeactive[i].SetActive(false);

                if (i == labSwarmsDeactive.Length - 1)
                {
                    swarmDeactiveDone = true;
                }
            }

            if (doorDone == true && swarmDone == true)
            {
                labDome = true;
            }
        }

        if (Inventory.lQFuzeObtained == true && generalDome == false)
        {
            bool doorDone = false;

            if(generalLights != null)
                generalLights.SetActive(false);

            for (int i = 0; i < generalDoors.Length; i++)
            {
                generalDoors[i].SetActive(false);

                if (i == generalDoors.Length - 1)
                {
                    doorDone = true;
                }
            }

            if (doorDone == true)
            {
                generalDome = true;
            }
        }
    }
}
