using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

    InteractWithObjects input;

    private void Awake()
    {
        input = new InteractWithObjects();
        input.Inventory.InventoryUIMenu.performed += x => InventoryUIMenu(); //set which actions to be done
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    void UpdateUI ()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count) //if there is more items to add
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else //if there is no more items to add
            {
                slots[i].ClearSlot();
            }
        }
    }

    private void OnEnable()
    {
        input.Inventory.Enable();
    }

    private void OnDisable()
    {
        input.Inventory.Disable();
    }

    private void InventoryUIMenu()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}
