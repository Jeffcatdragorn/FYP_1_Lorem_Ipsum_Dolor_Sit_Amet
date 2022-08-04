using UnityEngine;
using TMPro;
using System.Collections;

public class ItemPickup : Interactable
{
    //Interactable item;
    public GameObject cameraObject;
    public GameObject player;

    public HumanoidLandInput input;

    public Item item;

    public GameObject pickupPrompt;
    public TextMeshProUGUI itemNameText;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);

        //Add to inventory
        bool wasPickedUp = Inventory.instance.Add(item, gameObject);
        Debug.Log("wasPickedUp = " + wasPickedUp);
        AudioManager.instance.PlaySound("itemPickUp", cameraObject.transform.position, false);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        float dist = Vector3.Distance(player.transform.position, gameObject.transform.position); //distance between player and the item
        if (dist < radius)
        {
            itemNameText.text = item.name;
            pickupPrompt.SetActive(true);

            if (input.InteractIsPressed == true)
            {
                Interact();
                pickupPrompt.SetActive(false);
            }
        }
        else
        {
            if (itemNameText.text == item.name) //this doesn't work if there's more than 1 same item in the scene
            {
                pickupPrompt.SetActive(false);
            }
            
        }
    }
}
