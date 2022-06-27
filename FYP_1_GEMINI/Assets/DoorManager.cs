using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public bool door1;
    public bool door2;
    public GameObject seconddoor;
    bool booleanChecker = false;
    bool tempChecker;
    public Animator anim;
    private void Update()
    {
        if (door2 == true)
        {
            tempChecker = seconddoor.gameObject.GetComponent<DoorManager>().booleanChecker;
            if(tempChecker == true)
            {
                anim.SetBool("open", true);
            }
        }
    }
    public void BooleanChecker()
    {
        if(door1 == true)
        {
            booleanChecker = true;
            Debug.Log("sorry");
        }
        
    }
}
