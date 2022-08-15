using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;
    public TextMeshProUGUI textComponent;
    public HumanoidLandInput input;

    private void Awake()
    {
        if(_instance != null && _instance != this) //only one tooltip can exist at a time
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = new Vector3(input.MousePosition.x, input.MousePosition.y, 0.0f);
        transform.position = input.MousePosition;
    }

    public void SetAndShowTooltip(string message)
    {
        gameObject.SetActive(true);
        textComponent.text = message;

        if(textComponent.text == string.Empty) //after item is removed, tooltip shouldn't appear anymore
        {
            gameObject.SetActive(false);
        }
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }
}
