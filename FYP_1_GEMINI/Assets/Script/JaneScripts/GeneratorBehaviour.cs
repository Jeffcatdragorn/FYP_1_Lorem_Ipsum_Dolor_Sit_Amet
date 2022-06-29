using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBehaviour : MonoBehaviour
{
    [SerializeField] HumanoidLandInput input;
    [SerializeField] PlatformBehaviour platformBehaviour;
    [SerializeField] float generatorCooldownCounter;
    [SerializeField] float generatorCooldown;

    private void OnTriggerStay(Collider other)
    {
        if(input.InteractIsPressed == true && generatorCooldownCounter == 0.0f)
        {
            platformBehaviour.GeneratorInteract(gameObject.tag);
            generatorCooldownCounter = generatorCooldown;
        }
    }

    private void Update()
    {
        SetGeneratorCooldown();
    }

    void SetGeneratorCooldown()
    {
        if (generatorCooldownCounter > 0)
        {
            generatorCooldownCounter -= Time.deltaTime;
        }

        if (generatorCooldownCounter <= 0)
        {
            generatorCooldownCounter = 0.0f;
        }
    }
}
