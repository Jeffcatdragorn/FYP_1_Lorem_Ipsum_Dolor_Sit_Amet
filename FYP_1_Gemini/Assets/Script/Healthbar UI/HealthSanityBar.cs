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
    public bool isCD;
    private bool healed;
    private bool canHeal;

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

    }

    void Update()
    {
        //FIX !
        if(cinemachineThirdPerson == cc.activeCamera)
        {
            if (currSanity < maxSanity)
            {
                if (isCD == false)
                {
                    isCD = true;
                    StartCoroutine(SanityIncrease(10));

                }
            }   
        }

        else if(cinemachineFirstPerson == cc.activeCamera)
        {
            HealingHealth(5, 2);
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
        canHeal = true;
        currHealth -= damageTaken;
        return currHealth;
    }

    public float HealingHealth(float healAmount, float healDuration)
    {
        if(currHealth < maxHealth && canHeal == true)
        {
            currHealth += healAmount;
            ParasiteDamage(healAmount);
            StartCoroutine(Healing(healDuration));
        }
        return currHealth;
    }
    public float ParasiteDamage(float decrement)
    {
        currSanity -= decrement;
        return currSanity;
    }
    IEnumerator SanityIncrease(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("1111");
        HealthDamage(5);
        currSanity += sanityIncrement;
        isCD = false;
    }

    IEnumerator Healing(float healduration)
    {
        canHeal = false;
        yield return new WaitForSeconds(healduration);
        Debug.Log("Healing");
        canHeal = true;
    }
}
