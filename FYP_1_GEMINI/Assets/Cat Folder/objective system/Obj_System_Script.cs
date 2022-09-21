using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obj_System_Script : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject content;
    private Animator popupAnimator;
    private GameObject temp;

    private void Start()
    {
        popupAnimator = this.transform.GetComponent<Animator>();
    }

    public void InstantiateObjPopUpNoti(string text)
    {
        GameObject popUpNoti = Instantiate(button, content.transform, false);
        popUpNoti.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        popupAnimator.Play("PopPopAnimation");
        temp = popUpNoti;
        //Destroy(popUpNoti, 5);
    }
    public void DestroyObjPopUpNoti()
    {
        //Debug.Log("destroying");
        Destroy(temp);
    }


}
