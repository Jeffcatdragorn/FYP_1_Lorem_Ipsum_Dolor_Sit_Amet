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
        if (!source.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
