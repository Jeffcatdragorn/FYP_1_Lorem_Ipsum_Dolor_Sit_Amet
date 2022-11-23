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

    public static bool labKeyObtained = false;
    public static bool lQKeyObtained = false;
    public static bool generatorKeyObtained = false;

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
        //if(input.TabletIsPressed == true && tabletObtained == true && tabletUICooldownCounter == 0.0f && PauseMenu.GameIsPaused == false) //&& inventoryUI.activeInHierarchy == false
        //{
        //    TabletUIMenu(); 
        //    tabletUICooldownCounter = tabletUICooldown;
        //}

        //if (tabletMainScreenUI.activeInHierarchy == true || inventoryUI.activeInHierarchy == true)
        //{
        //    if (input.TabletScrollWheel < 0)
        //    {
        //        Debug.Log("scroll down");
        //        panelIndex++;
        //        //anim.Play("scroll Left");
        //        anim.Play("scroll Down");
        //        if (panelIndex > panels.Length - 1)
        //        {
        //            panelIndex = panels.Length - 1;
        //        }
        //    }
        //    if (input.TabletScrollWheel > 0)
        //    {
        //        Debug.Log("scroll up");
        //        panelIndex--;
        //        //anim.Play("scroll Right");
        //        anim.Play("scroll Up");

        //        if (panelIndex < 0)
        //        {
        //            panelIndex = 0;
        //        }
        //    }
        //    OpenSelectedUI();
        //}

        //if (tabletUICooldownCounter > 0)
        //{
        //    tabletUICooldownCounter -= Time.deltaTime;
        //}

        //if (tabletUICooldownCounter <= 0)
        //{
        //    tabletUICooldownCounter = 0.0f;
        //}

        //if (tabletMainScreenUI.activeInHierarchy == true)
        //{
        //    buttonManager.EnableMouseCursor();
        //}
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
                    items[i].itemAmount += item.itemAmount; //how to add bullets item amount?

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
            if (item.name == "Level 1 Key") //lab key
            {
                labKeyObtained = true;
            }
            if (item.name == "Level 2 Key") //LivingQuartersKey
            {
                lQKeyObtained = true;
            }
            if (item.name == "GeneratorKey")
            {
                generatorKeyObtained = true;
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

    //private void TabletUIMenu()
    //{
    //    tabletMainScreenUI.SetActive(!tabletMainScreenUI.activeSelf);
    //    inventoryUI.SetActive(!inventoryUI.activeSelf);

    //    AudioManager.instance.PlaySound("tabletOning", cameraObject.position, false);

    //    if (tabletMainScreenUI.activeInHierarchy == true)
    //    {
    //        buttonManager.EnableMouseCursor();
    //    }
    //    else
    //    {
    //        buttonManager.DisableMouseCursor();
    //    }
    //}

    //void OpenSelectedUI()
    //{
    //    for (int i = 0; i < panels.Length; i++)
    //    {
    //        panels[i].SetActive(false);
    //    }
    //    panels[panelIndex].SetActive(true);
    //}
}