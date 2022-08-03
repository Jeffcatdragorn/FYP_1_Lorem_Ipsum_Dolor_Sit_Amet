using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenLights : MonoBehaviour
{
    void Update()
    {
        AudioManager.instance.PlaySound("alarmSound",transform.position,false);
        transform.Rotate(new Vector3(0, -100, 0) * Time.deltaTime);
    }
}
