using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField] GameObject level1, level2, level3; //level1 is ground floor
    [SerializeField] int type;
    [SerializeField] GameObject connectedTile;
    public PickUpObjects pickUpObjects;
    public static bool generator1State;
    public static bool generator2State;

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

    private void Update()
    {
        if(generator1State == true && generator2State == false && connectedTile != null)
        {
            connectedTile.transform.position = level2.transform.position;
            connectedTile.transform.rotation = level2.transform.rotation;
        }

        if (generator1State == true && generator2State == true && connectedTile != null)
        {
            connectedTile.transform.position = level3.transform.position;
            connectedTile.transform.rotation = level3.transform.rotation;
        }

        if (generator1State == false && generator2State == true && connectedTile != null)
        {
            connectedTile.transform.position = level1.transform.position;
            connectedTile.transform.rotation = level1.transform.rotation;
        }

        if (generator1State == false && generator2State == false && connectedTile != null)
        {
            connectedTile.transform.position = level1.transform.position;
            connectedTile.transform.rotation = level1.transform.rotation;
        }

        Debug.Log("generator1State = " + generator1State);
        Debug.Log("generator2State = " + generator2State);
    }

    public void GeneratorInteract(string generatorTag)
    {
        if(generatorTag == "gen1")
        {
            if(generator1State == true)
                generator1State = false;
            else
                generator1State = true;
        }

        else if(generatorTag == "gen2")
        {
            if (generator2State == true)
                generator2State = false;
            else
                generator2State = true;
        }
    }
}
