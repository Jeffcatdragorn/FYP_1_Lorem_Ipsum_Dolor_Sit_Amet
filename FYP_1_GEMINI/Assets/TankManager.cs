using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    Animator anim;
    public Transform target;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(anim.GetBool("walk") == true)
        {
            Vector3.MoveTowards(transform.position, target.transform.position, 2f);
        }
    }
}
