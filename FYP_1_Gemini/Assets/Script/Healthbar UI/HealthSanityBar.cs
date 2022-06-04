using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class HealthSanityBar : MonoBehaviour
{
    public float maxHealth = 100;
    public float maxSanity = 100;

    public float sanityIncrement = 0.01f;
    private float currHealth;
    private float currSanity;

    public Image healthBar;
    public Image sanityBar;

    CinemachineVirtualCamera activeCamera;
    public CameraController cc;
    public CinemachineVirtualCamera cinemachineFirstPerson;
    public CinemachineVirtualCamera cinemachineThirdPerson;
    void Start()
    {
        currHealth = maxHealth;
        currSanity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cinemachineThirdPerson == cc.activeCamera)
        {
            if(currSanity < 100)
                currSanity += sanityIncrement * Time.deltaTime;
        }

        HealthFiller();
        SanityFiller();
    }

    public void HealthFiller()
    {
        healthBar.fillAmount = currHealth / maxHealth;
    }

    public void SanityFiller()
    {
        sanityBar.fillAmount = currSanity / maxSanity;
    }


}
