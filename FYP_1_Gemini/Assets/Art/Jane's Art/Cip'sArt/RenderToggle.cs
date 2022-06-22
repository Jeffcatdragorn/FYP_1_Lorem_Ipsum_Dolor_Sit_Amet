using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public class Toggler
{
    public ScriptableRendererFeature feature;
    public bool Enable;
}
//[ExecuteAlways]
public class RenderToggle : MonoBehaviour
{
    public UniversalRendererData rendererData;
    [SerializeField]
    public List<Toggler> features = new List<Toggler>();
    private bool f1;
    private bool f2;

    [SerializeField] HumanoidLandInput input;
    CombatControls combatInput = null;

    private void Start()
    {
        InvokeRepeating("ToggleEnable", 2.0f, 1.5f);
    }

    public void ToggleEnable()
    {
        if(features[0].Enable == true)
        {
            features[0].Enable = false;
            features[0].feature.SetActive(features[0].Enable);
        }
        else
            features[0].Enable = true;
            features[0].feature.SetActive(features[0].Enable);
    }
}
