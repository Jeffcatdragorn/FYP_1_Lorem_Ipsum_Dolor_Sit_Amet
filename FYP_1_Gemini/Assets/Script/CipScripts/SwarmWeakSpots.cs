using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmWeakSpots : MonoBehaviour
{
    public List<GameObject> WeakPointsList;
    public GameObject weakpoint;
    public int weakpointSelector;

    // Start is called before the first frame update
    void Start()
    {
        weakpointSelector = Random.Range(0, 6);
        weakpoint = WeakPointsList[weakpointSelector];
        weakpoint.SetActive(true);
    }
}
