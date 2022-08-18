using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLight : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    private float distance;
    public float lightRadius;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = transform.GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance < lightRadius)
        {
            // uncomment the animator line if u dont want them all to beep in sync
            //this.transform.GetComponent<Animator>().enabled = true; 
            this.transform.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            //this.transform.GetComponent<Animator>().enabled = false;
            this.transform.GetComponent<MeshRenderer>().enabled = false;
            //transform.localScale = Vector3.zero;
        }
    }
}
