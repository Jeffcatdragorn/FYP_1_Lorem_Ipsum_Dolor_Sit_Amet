using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParentXYZ : MonoBehaviour
{
    public Transform followParent;
    void Update()
    {
        this.gameObject.transform.position = new Vector3(followParent.position.x, followParent.position.y, followParent.position.z);
    }
}
