using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_System_Collider_Script : MonoBehaviour
{
    #region objective System
    private bool objDone = false;
    private bool objPopUp = false;
    private Obj_System_Script obj_System;
    public string objColliderName;
    #endregion
    #region ignore collision
    public GameObject playerObjCollider;
    #endregion
    #region input
    public HumanoidLandInput input;
    #endregion

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
    #region Shift
    public bool SHIFT = false;
    private int shift = 0;
    #endregion
    #region Space
    public bool SPACE = false;
    private int space = 0;
    #endregion
    #region Exit 1
    public bool EXIT1 = false;
    private int exit1 = 0;
    #endregion
    #endregion
    void Start()
    {
        obj_System = GameObject.FindObjectOfType<Obj_System_Script>();
        objDone = false;
        objPopUp = false;
        Physics.IgnoreCollision(playerObjCollider.GetComponent<Collider>(), GetComponent<Collider>());
    }
    void Update()
    {
        #region Input Checkers
        if (input.MoveIsPressed)                PressToDestroyWASD(input.MoveInput);
        if (input.CrouchIsPressed == true)      PressToDestroyCtrl();
        if (input.RunIsPressed == true)         PressToDestroyShift();
        if (input.JumpIsPressed == true)        PressToDestroySpace();
        #endregion
        #region Bool Checkers
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
        if (SHIFT && shift > 0)
        {
            obj_System.DestroyObjPopUpNoti();
            objDone = true;
            Destroy(gameObject);
        }
        if (SPACE && space > 0)
        {
            obj_System.DestroyObjPopUpNoti();
            objDone = true;
            Destroy(gameObject);
        }
        #endregion
    }
    #region WASD Functions
    public void PressToDestroyWASD(Vector2 input)
    {
        //Debug.Log(input.ToString());
        if (input == Vector2.up) PressToDestroyW();
        if (input == Vector2.left) PressToDestroyA();
        if (input == Vector2.down) PressToDestroyS();
        if (input == Vector2.right) PressToDestroyD();
    }
    //public void IncIndexNum(int key)
    //{
    //    Debug.Log(key.ToString());
    //    if (!objDone && objPopUp && key <= 0)
    //    {
    //        key++;
    //        Debug.Log(key);
    //    }
    //}
    public void PressToDestroyW()
    {
        if (!objDone && objPopUp && w <= 0) w++;
    }
    public void PressToDestroyA()
    {
        if (!objDone && objPopUp && a <= 0) a++;
    }
    public void PressToDestroyS()
    {
        if (!objDone && objPopUp && s <= 0) s++;
    }
    public void PressToDestroyD()
    {
        if (!objDone && objPopUp && d <= 0) d++;
    }
    #endregion
    #region CTRL Functions
    public void PressToDestroyCtrl()
    {
        if (!objDone && objPopUp && ctrl <= 0) ctrl++;
    }
    #endregion
    #region Shift Functions
    public void PressToDestroyShift()
    {
        if (!objDone && objPopUp && shift <= 0) shift++;
    }
    #endregion
    #region Space Functions
    public void PressToDestroySpace()
    {
        if (!objDone && objPopUp && space <= 0) space++;
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
        // exit -> only destroy the pop up because
        // they might not finish the job yet
        if (!objDone && objPopUp)
        {
            objPopUp = !objPopUp;
            obj_System.DestroyObjPopUpNoti();
        }
    }
}
