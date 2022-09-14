using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_System_Collider_Script : MonoBehaviour
{
    private bool objDone = false;
    private bool objPopUp = false;
    private Obj_System_Script obj_System;
    public string objColliderName;

    #region Collider Purpose and Variables
    #region WASD Variables
    public bool WASD = false;
    private int w = 0;
    private int a = 0;
    private int s = 0;
    private int d = 0;
    #endregion
    #region CTRL Variables
    public bool CTRL = false;
    private int ctrl = 0;
    #endregion
    #endregion
    void Start()
    {
        obj_System = GameObject.FindObjectOfType<Obj_System_Script>();
        objDone = false;
        objPopUp = false;
    }
    void Update()
    {
        if (WASD && w > 0 && a > 0 && s > 0 && d > 0)
        {
            obj_System.DestroyObjPopUpNoti();
            objDone = true;
            Destroy(gameObject);
        }
        if (CTRL && ctrl > 0)
        {
            obj_System.DestroyObjPopUpNoti();
            objDone = true;
            Destroy(gameObject);
        }
    }
    #region WASD Functions
    public void PressToDestroyW()
    {
        if (!objDone && objPopUp && w <= 0)
            w++;
    }
    public void PressToDestroyA()
    {
        if (!objDone && objPopUp && a <= 0)
            a++;
    }
    public void PressToDestroyS()
    {
        if (!objDone && objPopUp && s <= 0)
            s++;
    }
    public void PressToDestroyD()
    {
        if (!objDone && objPopUp && d <= 0)
            d++;
    }
    #endregion
    #region ctrl
    public void PressToDestroyCtrl()
    {
        if (!objDone && objPopUp && ctrl <= 0)
            ctrl++;
    }
    #endregion

    public void OnTriggerStay(Collider col)
    {
        // collide -> pop up
        if (col.gameObject.tag == "Player" && !objPopUp)
        {
            obj_System.InstantiateObjPopUpNoti(objColliderName);
            objPopUp = true; // pop up once only
        }
    }

    public void OnTriggerExit(Collider other)
    {
        // exit -> 1 way only
        obj_System.DestroyObjPopUpNoti();
        objDone = true;
        Destroy(gameObject);
    }
}
