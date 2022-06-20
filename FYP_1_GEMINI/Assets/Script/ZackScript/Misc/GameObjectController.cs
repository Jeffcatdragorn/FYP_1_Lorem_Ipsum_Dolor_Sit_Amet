using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    [SerializeField] public List<GameObject> normalObjects = new List<GameObject>();
    [SerializeField] public List<GameObject> destroyedObjects = new List<GameObject>();

    public void changeForms(string objectName)
    {
        Debug.Log("yea");
        for(int i = 0; i < normalObjects.Count; i++)
        {
            if(normalObjects[i].name == objectName)
            {
                normalObjects[i].SetActive(false);
                destroyedObjects[i].SetActive(true);
            }

            else
            {
                Debug.Log("GG you didnt set properly haiyaa");
            }
        }
    }
}
