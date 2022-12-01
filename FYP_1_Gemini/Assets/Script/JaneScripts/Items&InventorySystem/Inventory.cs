using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    //public GameObject tabletMainScreenUI;
    //public GameObject inventoryUI;
    public GameObject canvas;
    public static bool tabletObtained = false;
    public static bool flashlightObtained = false;
    public static bool gunObtained = false;

    public static bool lvl1KeyObtained = false;
    public static bool lvl2KeyObtained = false;
    public static bool lvl3KeyObtained = false;

    public static bool prisonFuzeObtained = false;
    public static bool labFuzeObtained = false;
    public static bool lQFuzeObtained = false;
    public static bool generatorFuzeObtained = false;

    //public HumanoidLandInput input;

    //public GameObject[] panels;
    //private int panelIndex;
    //public Animator anim;

    //public ButtonManager buttonManager;
    //[SerializeField] float tabletUICooldownCounter;
    //[SerializeField] float tabletUICooldown;

    //public Transform cameraObject;

    public Transform inspectTransform;
    public GameObject inspectUI;
    public GameObject inspectObject;
    public GameObject inspectCamera;
    public static pop_up_script popUpScript;

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        popUpScript = GameObject.FindObjectOfType<pop_up_script>();

        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this; //you should only have one inventory at all times!
    }

    #endregion


    private void Update()
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i].itemAmount <= 0)
            {
                items[i].itemAmount = 1;
                items.Remove(items[i]);
                Debug.Log("REMOVEDDDDDDDDDDDDDDDDD " + items[i]);
            }
        }
    }

    public bool Add(Item item, GameObject itemObject)
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
                    items[i].itemAmount++;

                    if (onItemChangedCallback != null)
                    {
                        onItemChangedCallback.Invoke();
                    }

                    return true;
                }
            }

            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        else //item is default item (e.g. tablet)
        {
            if (item.name == "Tablet")
            {
                tabletObtained = true;
                canvas.GetComponent<InventoryUI>().enabled = true;
            }
            if (item.name == "Flashlight")
            {
                flashlightObtained = true;
            }
            if (item.name == "Gun")
            {
                gunObtained = true;
            }
            if (item.name == "Level 1 Key") //LabDomeKey
            {
                lvl1KeyObtained = true;
            }
            if (item.name == "Level 2 Key") //GeneralSectorKey
            {
                lvl2KeyObtained = true;
            }
            if (item.name == "Level 3 Key") //GeneratorDomeKey
            {
                lvl3KeyObtained = true;
            }
            if (item.name == "PrisonFuze")
            {
                prisonFuzeObtained = true;
            }
            if (item.name == "LabFuze")
            {
                labFuzeObtained = true;
            }
            if (item.name == "LivingQuartersFuze")
            {
                lQFuzeObtained = true;
            }
            if (item.name == "GeneratorFuze")
            {
                generatorFuzeObtained = true;
            }
        }

        return true;
    }


    public void Remove(Item item)
    {
        items.Remove(item);
        popUpScript.InstantiatePopUpNoti("Removed " + item.name);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}