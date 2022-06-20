using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineColour : MonoBehaviour
{
    public Material materialShader;
    public float thiccness = 1.03f;
    [ColorUsage(true, true)]
    public Color colorOutline;
    private Renderer outlineRender;
    public Transform originalShape;
    void Start()
    {
       
        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, originalShape);
        outlineObject.transform.localScale = new Vector3(1, 1, 1);
        outlineRender = outlineObject.GetComponent<Renderer>();
        outlineRender.material = materialShader;
        outlineRender.material.SetFloat("_Thickness", thiccness);
        outlineRender.material.SetColor("_OutlineColour", colorOutline);
        outlineRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        outlineRender.enabled = true;
        outlineObject.GetComponent<Collider>().enabled = false;
        outlineObject.GetComponent<OutlineColour>().enabled = false; //Avoid Double outlines.
        this.outlineRender = outlineRender;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
