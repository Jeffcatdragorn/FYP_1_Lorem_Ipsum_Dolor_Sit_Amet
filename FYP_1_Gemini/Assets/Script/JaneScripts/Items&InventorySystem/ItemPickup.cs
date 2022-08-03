using UnityEngine;

public class ItemPickup : Interactable
{
    //Interactable item;
    public GameObject cameraObject;
    public GameObject player;

    public HumanoidLandInput input;

    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);

        //Add to inventory
        bool wasPickedUp = Inventory.instance.Add(item);
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
            if (input.InteractIsPressed == true)
            {
                Interact();
            }
        }
    }
}
