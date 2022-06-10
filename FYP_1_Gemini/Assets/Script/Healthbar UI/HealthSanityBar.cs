using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class HealthSanityBar : MonoBehaviour
{
    public float maxHealth = 100;
    public float maxSanity;

    public float sanityIncrement = 0.01f;
    private float currHealth;
    private float currSanity;
    private bool startCorouA;
    private bool startCorouB;

    public Image healthBar;
    public Image sanityBar;
    private Coroutine regen;
    private Coroutine degen;

    CinemachineVirtualCamera activeCamera;
    public CameraController cc;
    public CinemachineVirtualCamera cinemachineFirstPerson;
    public CinemachineVirtualCamera cinemachineThirdPerson;

    void Start()
    {
        currHealth = maxHealth;
        maxSanity = 100;
        currSanity = 0;
        startCorouA = true;
        startCorouB = true;
    }

    void Update()
    {
        //FIX !
        if(cinemachineThirdPerson == cc.activeCamera)
        {
            if(startCorouA == true)
            {
                if(regen != null)
                {
                    StopCoroutine(SanityIncrease());
                }
                regen = StartCoroutine(SanityIncrease());
            }
        }
        else if(cinemachineFirstPerson == cc.activeCamera)
        {
            if(startCorouB == true)
            {
               if(degen != null)
                {
                    StopCoroutine(SanityDecrease());
                }
                degen = StartCoroutine(SanityDecrease());
            }
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

    //Call function if we take damage
    public float HealthDamage(float damageTaken)
    {
        currHealth -= damageTaken;
        return currHealth;
    }

    IEnumerator SanityIncrease()
    {
        float delay = Time.deltaTime * 2;
        if (degen != null)
        {
            StopCoroutine(SanityDecrease());
        }
        while (currSanity < maxSanity)
        {
            currSanity += sanityIncrement;
            startCorouA = false;
            yield return new WaitForSeconds(delay);
            startCorouA = true;
        }
        regen = null;
    }

    IEnumerator SanityDecrease()
    {
        float delay = Time.deltaTime * 2;
        if(regen != null)
        {
            StopCoroutine(SanityIncrease());
        }
        while (currSanity > 0)
        {
            currSanity -= sanityIncrement;
            startCorouB = false;
            yield return new WaitForSeconds(delay);
            startCorouB = true;
        }
        degen = null;
    }
}
