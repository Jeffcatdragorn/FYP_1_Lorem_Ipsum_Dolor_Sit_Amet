using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    //string message;
    //InventorySlot inventorySlot;
    private string message;

    public void tooltipOn() //FUCKING JIBAI HOVERING NOT WORKING
    {
        message = this.gameObject.GetComponent<InventorySlot>().tooltipMessage;
        TooltipManager._instance.SetAndShowTooltip(message);

        Debug.Log("message" + message);
    }

    public void tooltipOff()
    {
        TooltipManager._instance.HideTooltip();
    }

}
