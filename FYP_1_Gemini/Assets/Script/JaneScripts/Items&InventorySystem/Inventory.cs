using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this; //you should only have one inventory at all times!
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public GameObject tabletUI;
    public GameObject canvas;
    public static bool tabletObtained = false;
    public static bool flashlightObtained = false;
    public HumanoidLandInput input;
    public ButtonManager buttonManager;
    [SerializeField] float tabletUICooldownCounter;
    [SerializeField] float tabletUICooldown;

    public Transform cameraObject;

    public Transform inspectTransform;
    public GameObject inspectUI;
    public GameObject inspectObject;
    public GameObject inspectCamera;

    private void Update()
    {
        if(input.TabletIsPressed == true && tabletObtained == true && tabletUICooldownCounter == 0.0f)
        {
            TabletUIMenu(); 
            tabletUICooldownCounter = tabletUICooldown;
        }

        if (tabletUICooldownCounter > 0)
        {
            tabletUICooldownCounter -= Time.deltaTime;
        }

        if (tabletUICooldownCounter <= 0)
        {
            tabletUICooldownCounter = 0.0f;
        }

        if (tabletUI.activeInHierarchy == true)
        {
            buttonManager.EnableMouseCursor();
        }
    }

    public bool Add (Item item, GameObject itemObject)
    {
        inspectUI.SetActive(true);
        inspectCamera.SetActive(true);
        if (inspectObject == null)
        {
            inspectObject = Instantiate(itemObject, inspectTransform);
            inspectObject.GetComponent<Rigidbody>().useGravity = false;
            inspectObject.transform.parent = inspectTransform;
            inspectObject.transform.position = inspectTransform.transform.position;
        }
        else
        {
            Destroy(inspectObject);
            inspectObject = Instantiate(itemObject, inspectTransform);
            inspectObject.GetComponent<Rigidbody>().useGravity = false;
            inspectObject.transform.parent = inspectTransform;
            inspectObject.transform.position = inspectTransform.transform.position;
        }

        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough inventory space.");
                return false;
            }

            //Item copyItem = Instantiate(item);

            for (int i = 0; i < items.Count; i++) //stackable items (FIX NEEDED)
            {
                if (items[i].name == item.name)
                {
                    items[i].itemAmount += item.itemAmount; //how to add bullets item amount?

                    if (onItemChangedCallback != null)
                    {
                        onItemChangedCallback.Invoke();
                    }
                    
                    return true;
                }
            }

            items.Add(item);

            if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        else //item is default item (e.g. tablet)
        {
            if(item.name == "Tablet")
            {
                tabletObtained = true;
                canvas.GetComponent<InventoryUI>().enabled = true;
            }

            if (item.name == "Flashlight")
            {
                flashlightObtained = true;
            }
        }

        return true;
    }
    

    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    private void TabletUIMenu()
    {
        if(tabletObtained == true)
        {
            tabletUI.SetActive(!tabletUI.activeSelf);
            AudioManager.instance.PlaySound("tabletOning", cameraObject.position, false);

            if(tabletUI.activeInHierarchy == true)
            {
                buttonManager.EnableMouseCursor();
            }
            else
            {
                buttonManager.DisableMouseCursor();
            }
        }
    }
}