using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";    //Name of the item
    public Sprite icon = null;              //Item icon
    public bool isDefaultItem = false;      //Is the item default wear?
    public int itemAmount;
    public string tooltipMessage;

    public virtual void Use ()
    {
        //Use the item
        //something might happen

        Debug.Log("Using " + name);
    }
}
