using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    public Light FlickerLight;

    void Update()
    {
        FlickerLight.intensity = Random.Range(10, 19);
    }
}
