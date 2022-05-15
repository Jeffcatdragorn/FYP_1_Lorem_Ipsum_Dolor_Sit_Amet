using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision fist)
    {
        if(fist.transform.tag == "Fist")
        {
            Debug.LogWarning("Collided");
        }
    }

    private void OnTriggerEnter(Collider fist)
    {
        if (fist.transform.tag == "Fist")
        {
            Debug.LogWarning("Collided");
        }
    }
}
