using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public Transform cameraObject;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

    public HumanoidLandInput input;
    public ButtonManager buttonManager;
    [SerializeField] float inventoryUICooldownCounter;
    [SerializeField] float inventoryUICooldown;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void Update()
    {
        if(input.InventoryIsPressed == true && Inventory.tabletObtained == true && inventoryUICooldownCounter == 0.0f)
        {
            InventoryUIMenu();
            inventoryUICooldownCounter = inventoryUICooldown;
        }

        if (inventoryUICooldownCounter > 0)
        {
            inventoryUICooldownCounter -= Time.deltaTime;
        }

        if (inventoryUICooldownCounter <= 0)
        {
            inventoryUICooldownCounter = 0.0f;
        }
    }

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

    private void InventoryUIMenu()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        AudioManager.instance.PlaySound("tabletOning", cameraObject.position);

        if (inventoryUI.activeInHierarchy == true)
        {
            buttonManager.EnableMouseCursor();
        }
        else
        {
            buttonManager.DisableMouseCursor();
        }
    }
}
