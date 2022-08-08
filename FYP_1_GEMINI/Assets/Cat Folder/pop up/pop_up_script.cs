using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pop_up_script : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject content;
    private Animator popupAnimator;



    void Start()
    {
        popupAnimator = this.transform.GetComponent<Animator>();
    }

    public void InstantiateButton(string text)
    {
        GameObject popUpNoti = Instantiate(button, content.transform,false);
        popUpNoti.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        popupAnimator.Play("PopPopAnimation");
        
        Destroy(popUpNoti,2);
    }
}
