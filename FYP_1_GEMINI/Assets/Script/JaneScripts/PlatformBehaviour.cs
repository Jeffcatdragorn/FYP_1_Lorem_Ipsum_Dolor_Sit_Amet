using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField] GameObject level1, level2, level3;
    [SerializeField] int type;
    [SerializeField] GameObject connectedTile;
    public PickUpObjects pickUpObjects;

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<TileBehaviour>().type == this.type && connectedTile == null)
        {
            pickUpObjects.LetGoOfObject();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.transform.position = level1.transform.position;
            other.gameObject.transform.rotation = level1.transform.rotation;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.layer = 16 ; //layer = tiles
            //other.gameObject.transform.parent = gameObject.transform;

            connectedTile = other.gameObject;
        }
    }
}
