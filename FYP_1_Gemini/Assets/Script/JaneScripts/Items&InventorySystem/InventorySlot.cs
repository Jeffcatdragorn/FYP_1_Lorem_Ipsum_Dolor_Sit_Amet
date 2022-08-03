using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public TextMeshProUGUI numberOfItems;
    public PlayerController playerController;

    [SerializeField]Item item;

    public string tooltipMessage;

    private void Start()
    {
        numberOfItems.enabled = false;
    }

    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        tooltipMessage = item.tooltipMessage;
        numberOfItems.enabled = true;
        numberOfItems.text = newItem.itemAmount.ToString("0");
    }

    public void ClearSlot ()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        tooltipMessage = string.Empty;
        numberOfItems.enabled = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem ()
    {
        if (item != null)
        {
            item.Use();
            numberOfItems.text = item.itemAmount.ToString("" + item.itemAmount);

            if (item.name == "CanDrink")
            {
                playerController.HealthIncrease(5);
            }
            else if (item.name == "SnackBar")
            {
                playerController.HealthIncrease(10);
            }
            else if (item.name == "Syringe")
            {
                playerController.HealthIncrease(25);
            }
        }

        if(item.itemAmount <= 0)
        {
            ClearSlot();
        }
    }
}