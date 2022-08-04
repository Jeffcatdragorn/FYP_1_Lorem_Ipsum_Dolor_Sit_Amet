using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenLights : MonoBehaviour
{
    //private void Start()
    //{
    //    AudioManager.instance.PlaySound("alarmSound", transform.position, false);
    //}

    void Update()
    {
        transform.Rotate(new Vector3(0, -100, 0) * Time.deltaTime);
    }
}
