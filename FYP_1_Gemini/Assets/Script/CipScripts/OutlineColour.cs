using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineColour : MonoBehaviour
{
    public Material materialShader;
    public float thiccness = 1.03f;
    [ColorUsage(true, true)]
    public Color colorOutline;
    private Renderer rend;
    public Transform parentObject;
    //private GameObject shadeObj;

    void Start()
    {
       GameObject shadeObj = Instantiate(this.gameObject, transform.position, transform.rotation,parentObject);
       shadeObj.transform.localScale = new Vector3(1, 1, 1);
       Renderer outlineRender = shadeObj.GetComponent<Renderer>();
       outlineRender.material = materialShader;
       outlineRender.material.SetFloat("_Thickness", thiccness);
       outlineRender.material.SetColor("_OutlineColour", colorOutline);
       outlineRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
       outlineRender.enabled = true;
       if (shadeObj.GetComponent<Collider>() != null)
       {
            shadeObj.GetComponent<Collider>().enabled = false;
       }
        shadeObj.GetComponent<OutlineColour>().enabled = false; //Avoid Double outlines.
        this.rend = outlineRender;
    }
}
