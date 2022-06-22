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
    CombatControls combatInput = null;

    private void Start()
    {
        InvokeRepeating("ToggleEnemyEnable", 2.0f, 1.5f);
    }

    public void ToggleEnemyEnable()
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
    
    public void TogglePickEnable()
    {
        if (features[1].Enable == true)
        {
            features[1].Enable = false;
            features[1].feature.SetActive(features[1].Enable);
        }
        else
            features[1].Enable = true;
            features[1].feature.SetActive(features[1].Enable);
    }
}
