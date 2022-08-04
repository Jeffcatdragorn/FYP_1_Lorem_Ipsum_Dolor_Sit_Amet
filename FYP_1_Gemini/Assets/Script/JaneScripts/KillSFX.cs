using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSFX : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(this.gameObject.transform.parent != null)
        {
            gameObject.transform.rotation = gameObject.transform.parent.rotation;
        }

        if (!source.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
