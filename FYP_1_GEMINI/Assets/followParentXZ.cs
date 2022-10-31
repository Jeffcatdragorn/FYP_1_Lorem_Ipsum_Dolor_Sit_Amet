using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followParentXZ : MonoBehaviour
{
    public Transform followParent;
    void Update()
    {
        this.gameObject.transform.position = new Vector3(followParent.position.x, this.gameObject.transform.position.y, followParent.position.z);
    }
}
