using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    public Light FlickerLight;
    public int minRange, maxRange;
    void Update()
    {
        FlickerLight.intensity = Random.Range(minRange, maxRange);
    }
}
