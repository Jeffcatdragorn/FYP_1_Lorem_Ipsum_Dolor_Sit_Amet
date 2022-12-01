using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public Transform cameraObject;
    //public GameObject inventoryUI;
    public GameObject tabletMainScreenUI;
    public GameObject tabletObj;

    Inventory inventory;

    public InventorySlot[] slots;

    public HumanoidLandInput input;

    //public GameObject[] panels;
    //private int panelIndex;
    //public Animator anim;

    public ButtonManager buttonManager;
    [SerializeField] float tabletUICooldownCounter;
    [SerializeField] float tabletUICooldown;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void Update()
    {
        if (input.TabletIsPressed == true && Inventory.tabletObtained == true && tabletUICooldownCounter == 0.0f)
        {
            TabletUIMenu();
            tabletUICooldownCounter = tabletUICooldown;
        }

        //if (tabletMainScreenUI.activeInHierarchy == true)
        //{
        //    if (input.TabletScrollWheel < 0)
        //    {
        //        //Debug.Log("scroll down");
        //        panelIndex++;
        //        //anim.Play("scroll Left");
        //        anim.Play("TabletScrollDown");
        //        if (panelIndex > panels.Length - 1)
        //        {
        //            panelIndex = panels.Length - 1;
        //        }
        //    }
        //    if (input.TabletScrollWheel > 0)
        //    {
        //        //Debug.Log("scroll up");
        //        panelIndex--;
        //        //anim.Play("scroll Right");
        //        anim.Play("TabletScrollUp");

        //        if (panelIndex < 0)
        //        {
        //            panelIndex = 0;
        //        }
        //    }
        //    OpenSelectedUI();
        //}

        if (tabletUICooldownCounter > 0)
        {
            tabletUICooldownCounter -= Time.deltaTime;
        }

        if (tabletUICooldownCounter <= 0)
        {
            tabletUICooldownCounter = 0.0f;
        }

        //if (inventoryUI.activeInHierarchy == true)
        //{
        //    buttonManager.EnableMouseCursor();
        //}
    }

    void UpdateUI()
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

    private void TabletUIMenu()
    {
        tabletMainScreenUI.SetActive(!tabletMainScreenUI.activeSelf);
        tabletObj.SetActive(!tabletObj.activeSelf);
        AudioManager.instance.PlaySound("tabletOning", cameraObject.position, false);

        if (tabletMainScreenUI.activeInHierarchy == true)
        {
            buttonManager.EnableMouseCursor();
        }
        else
        {
            buttonManager.DisableMouseCursor();
        }
    }

    //void OpenSelectedUI()
    //{
    //    for (int i = 0; i < panels.Length; i++)
    //    {
    //        panels[i].SetActive(false);
    //    }
    //    panels[panelIndex].SetActive(true);
    //}
}
