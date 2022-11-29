using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorDoorBehaviour : MonoBehaviour
{
    [SerializeField] private Animator normalDoorAnimator = null;
    [SerializeField] private string doorSlideOpen = "DoorSlideOpen";
    private bool fusePickedUp = false;

    private void Start()
    {
        fusePickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.generatorFuzeObtained == true && fusePickedUp == false)
        {
            normalDoorAnimator.Play(doorSlideOpen, 0, 0.0f);
            AudioManager.instance.PlaySound("doorOpening", normalDoorAnimator.gameObject.transform.GetChild(0).transform.position, true);

            fusePickedUp = true;
        }
    }
}
