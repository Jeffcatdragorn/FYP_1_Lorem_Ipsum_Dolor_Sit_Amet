using UnityEngine;

public class ItemPickup : Interactable
{
    //Interactable item;
    public GameObject player;

    InteractWithObjects input;

    public Item item;

    private void Awake()
    {
        input = new InteractWithObjects();
        input.InteractWithObject.PickUpItem.performed += x => Interact(); //set which actions to be done
    }

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

        if(wasPickedUp)
        {
            Destroy(gameObject);
        }
    }

    //private void Update()
    //{
    //    float dist = Vector3.Distance(player.transform.position, gameObject.transform.position); //distance between player and the item
    //    if (dist < item.radius)
    //    {
    //        Interact();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            input.InteractWithObject.Enable(); //enable the input (can use input)
        }
    }
}
