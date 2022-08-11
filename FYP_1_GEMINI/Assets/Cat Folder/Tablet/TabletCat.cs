using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletCat : MonoBehaviour
{
    TabletInput tabletInput;
    public GameObject camera;
    public float mouseScrollY;
    public GameObject[] buttons;
    private int buttonIndex;
    public Animator anim;
    public GameObject[] JaneUi;
    public float offsetX;
    public float offsetY;
    public float offsetZ;



    private void Awake()
    {
        tabletInput = new TabletInput();

        tabletInput.wheel.Scrolly.performed += x => mouseScrollY = x.ReadValue<float>();
        tabletInput.wheel.Select.performed += y => SelectThis();

    }

    private void Update()
    {
        //transform.position = camera.transform.position;
        //transform.position = 
            //new Vector3(camera.transform.position.x - offsetX, camera.transform.position.y - offsetY, camera.transform.position.z - offsetZ);
        if (mouseScrollY < 0f)
        {
            Debug.Log("scroll dwon");
            buttonIndex++;
            //anim.Play("scroll Left");
            anim.Play("scroll Down");
            if (buttonIndex > buttons.Length - 1)
            {
                buttonIndex = buttons.Length -1;
            }
        }
        if (mouseScrollY > 0f)
        {
            Debug.Log("scroll up");
            buttonIndex--;
            //anim.Play("scroll Right");
            anim.Play("scroll Up");

            if (buttonIndex < 0)
            {
                buttonIndex = 0;
            }
        }
        OpenSelectedUI();
    }
    void OpenSelectedUI()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        buttons[buttonIndex].SetActive(true);
    }
    void SelectThis()
    {
        Debug.Log("selected this");
        //anim.Play("scroll Press");
        anim.Play("scroll Press2");
        //switch (buttonIndex)
        //{
        //    case 0:
        //        JaneUi[buttonIndex].SetActive(true);
        //        buttons[buttonIndex].SetActive(false);
        //        break;
        //    case 1:
        //        JaneUi[buttonIndex].SetActive(true);
        //        buttons[buttonIndex].SetActive(false);
        //        break;
        //    case 2:
        //        JaneUi[buttonIndex].SetActive(true);
        //        buttons[buttonIndex].SetActive(false);
        //        break;
        //}
    }

    #region enable / disable
    private void OnEnable()
    {
        tabletInput.Enable();
    }
    private void OnDisable()
    {
        tabletInput.Disable();
    }
    #endregion
}
