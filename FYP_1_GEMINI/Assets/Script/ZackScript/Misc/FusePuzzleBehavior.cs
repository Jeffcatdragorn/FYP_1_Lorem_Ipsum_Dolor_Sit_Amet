using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FusePuzzleBehavior : MonoBehaviour
{
    public enum FuseBox
    {
        prison, lab, general, generator,
    }

    [System.Serializable]
    public class FuseSlot
    {
        public Transform slotPosition1;
        public Transform slotPosition2;
        public Button slotButton;
        public int fuseOccupying;
        public bool occupied;
    }

    [System.Serializable]
    public class FuseObject
    {
        public GameObject normal;
        public GameObject glow;
        public GameObject fuseSelectionButton;
    }

    public static int selectedFuse;
    public static int fusePuzzleCompletion;

    [SerializeField] HumanoidLandInput input;
    [SerializeField] GameObject player;
    [SerializeField] FuseBox thisFuseBox;
    [SerializeField] GameObject interactPanel;
    [SerializeField] GameObject lightSphere1;
    [SerializeField] GameObject lightSphere2;
    [SerializeField] GameObject slotUI;
    [SerializeField] GameObject fuseSelectionUI;
    [SerializeField] Material lightSphereNormalMaterial;
    [SerializeField] Material lightSphereGlowMaterial;
    [SerializeField] FuseSlot[] fuseSlots;
    [SerializeField] FuseObject[] fusePrefabs;
    [SerializeField] Animator elevatorDoor;
    [SerializeField] bool uiActive = false;
    [SerializeField] bool interactPanelBool = false;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] Transform centralHub;
    private Animator fuseBoxAnimator;

    private bool lit;
    private float cooldownTimer;

    bool reset = false;
    bool resetDone = false;
    int resetBoxNum;

    //[SerializeField] GameObject prisonFuse, labFuse, generalFuse, generatorFuse;

    private void Awake()
    {
        selectedFuse = 0;
        fuseBoxAnimator = this.gameObject.GetComponent<Animator>();
        boxCollider = this.gameObject.GetComponent<BoxCollider>();
        //Inventory.prisonFuzeObtained = true;
        //Inventory.labFuzeObtained = true;
        //Inventory.lQFuzeObtained = true;
        //Inventory.generatorFuzeObtained = true;
    }

    private void Update()
    {

        if (reset == true)
        {
            //if (lit == true)
            //{
            //    fusePuzzleCompletion -= 1;
            //    lit = false;
            //    lightSphere1.GetComponent<MeshRenderer>().material = lightSphereNormalMaterial;
            //    lightSphere2.GetComponent<MeshRenderer>().material = lightSphereNormalMaterial;
            //}

            for (int i = 0; i < fuseSlots.Length; i++)
            {
                if (fuseSlots[i].slotPosition1.childCount > 0)
                {
                    Destroy(fuseSlots[i].slotPosition1.GetChild(0).gameObject);
                    Destroy(fuseSlots[i].slotPosition2.GetChild(0).gameObject);
                }

                if (fuseSlots[i].occupied == true)
                {
                    int tempNum = fuseSlots[i].fuseOccupying;
                    fusePrefabs[tempNum - 1].fuseSelectionButton.GetComponent<Button>().interactable = true;

                    if(fusePrefabs[tempNum - 1].fuseSelectionButton.GetComponent<Button>().interactable == true)
                    {
                        fuseSlots[i].fuseOccupying = 0;
                        fuseSlots[i].occupied = false;
                    }
                }

                if (i == 4)
                {
                    reset = false;
                }
            }
        }

        if (Inventory.prisonFuzeObtained == true)
        {
            fusePrefabs[0].fuseSelectionButton.SetActive(true);
        }

        if (Inventory.labFuzeObtained == true)
        {
            fusePrefabs[1].fuseSelectionButton.SetActive(true);
        }

        if (Inventory.lQFuzeObtained == true)
        {
            fusePrefabs[2].fuseSelectionButton.SetActive(true);
        }

        if (Inventory.generatorFuzeObtained == true)
        {
            fusePrefabs[3].fuseSelectionButton.SetActive(true);
        }

        if(cooldownTimer >= 0.0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "playerFront")
        {
            if(interactPanelBool == false)
                interactPanel.SetActive(true);
            else
                interactPanel.SetActive(false);

            if (input.InteractIsPressed == true && uiActive == false && cooldownTimer <= 0.0f)
            {
                interactPanelBool = true;
                slotUI.SetActive(true);
                fuseSelectionUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                PlayerController.state = PlayerController.State.lockAll;
                uiActive = true;
                cooldownTimer = 0.5f;
            }

            if (input.InteractIsPressed == true && uiActive == true && cooldownTimer <= 0.0f)
            {
                interactPanelBool = false;
                slotUI.SetActive(false);
                fuseSelectionUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                PlayerController.state = PlayerController.State.free;
                uiActive = false;
                cooldownTimer = 0.5f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "playerFront")
        {
            interactPanel.SetActive(false);
        }
    }

    public void SelectedFuse(int i)
    {
        selectedFuse = i;
    }

    public void SlotClick(int i)
    {
        if (selectedFuse != 0)
        {
            AudioManager.instance.PlaySound("fuseSlotIn", centralHub.position, true);

            if (i == 1)
            {
                if (fuseSlots[i - 1].occupied == false)
                {
                    if (selectedFuse == 3 && this.thisFuseBox == FuseBox.general)
                    {
                        GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        lightSphere1.GetComponent<MeshRenderer>().material = lightSphereGlowMaterial;
                        lightSphere2.GetComponent<MeshRenderer>().material = lightSphereGlowMaterial;

                        //lit = true;

                        FusePuzzleBehavior.fusePuzzleCompletion += 1;
                        resetBoxNum = 3;
                        ResetBox();
                    }

                    else if (selectedFuse == 3)
                    {
                        GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;
                    }

                    else
                    {
                        GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        AudioManager.instance.PlaySound("PAerror", centralHub.position, true);
                    }

                    fusePrefabs[selectedFuse - 1].fuseSelectionButton.GetComponent<Button>().interactable = false;
                    fuseSlots[i - 1].fuseOccupying = selectedFuse;
                    fuseSlots[i - 1].occupied = true;
                    selectedFuse = 0;
                }
            }

            if (i == 2)
            {
                if (fuseSlots[i - 1].occupied == false)
                {
                    if (selectedFuse == 2 && this.thisFuseBox == FuseBox.lab)
                    {
                        GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        lightSphere1.GetComponent<MeshRenderer>().material = lightSphereGlowMaterial;
                        lightSphere2.GetComponent<MeshRenderer>().material = lightSphereGlowMaterial;

                        //lit = true;
                        FusePuzzleBehavior.fusePuzzleCompletion += 1;

                        resetBoxNum = 2;
                        ResetBox();
                    }

                    else if (selectedFuse == 2)
                    {
                        GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;
                    }
                    else
                    {
                        GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        AudioManager.instance.PlaySound("PAerror", centralHub.position, true);
                    }

                    fusePrefabs[selectedFuse - 1].fuseSelectionButton.GetComponent<Button>().interactable = false;
                    fuseSlots[i - 1].fuseOccupying = selectedFuse;
                    fuseSlots[i - 1].occupied = true;
                    selectedFuse = 0;
                }
            }

            if (i == 3)
            {
                if (fuseSlots[i - 1].occupied == false)
                {
                    if (selectedFuse == 4 && this.thisFuseBox == FuseBox.generator)
                    {
                        GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        lightSphere1.GetComponent<MeshRenderer>().material = lightSphereGlowMaterial;
                        lightSphere2.GetComponent<MeshRenderer>().material = lightSphereGlowMaterial;

                        //lit = true;
                        FusePuzzleBehavior.fusePuzzleCompletion += 1;

                        resetBoxNum = 4;
                        ResetBox();
                    }

                    else if (selectedFuse == 4)
                    {
                        GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;
                    }
                    else
                    {
                        GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        AudioManager.instance.PlaySound("PAerror", centralHub.position, true);
                    }

                    fusePrefabs[selectedFuse - 1].fuseSelectionButton.GetComponent<Button>().interactable = false;
                    fuseSlots[i - 1].fuseOccupying = selectedFuse;
                    fuseSlots[i - 1].occupied = true;
                    selectedFuse = 0;
                }
            }

            if (i == 4)
            {
                if (fuseSlots[i - 1].occupied == false)
                {
                    if (selectedFuse == 1 && this.thisFuseBox == FuseBox.prison)
                    {
                        GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        lightSphere1.GetComponent<MeshRenderer>().material = lightSphereGlowMaterial;
                        lightSphere2.GetComponent<MeshRenderer>().material = lightSphereGlowMaterial;

                        //lit = true;
                        FusePuzzleBehavior.fusePuzzleCompletion += 1;

                        resetBoxNum = 1;
                        ResetBox();
                    }

                    else if (selectedFuse == 1)
                    {
                        GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;
                    }
                    else
                    {
                        GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                        newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                        newPrefab.transform.localPosition = Vector3.zero;
                        newPrefab.transform.localScale = Vector3.one;

                        AudioManager.instance.PlaySound("PAerror", centralHub.position, true);
                    }

                    fusePrefabs[selectedFuse - 1].fuseSelectionButton.GetComponent<Button>().interactable = false;
                    fuseSlots[i - 1].fuseOccupying = selectedFuse;
                    fuseSlots[i - 1].occupied = true;
                    selectedFuse = 0;
                }
            }

            if (i == 5)
            {
                if (fuseSlots[i - 1].occupied == false)
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition1.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;

                    newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition2.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;

                    AudioManager.instance.PlaySound("PAerror", centralHub.position, true);

                    fusePrefabs[selectedFuse - 1].fuseSelectionButton.GetComponent<Button>().interactable = false;
                    fuseSlots[i - 1].fuseOccupying = selectedFuse;
                    fuseSlots[i - 1].occupied = true;
                    selectedFuse = 0;
                }
            }
        }
    }

    public void ResetSlots()
    {
        reset = true;

        selectedFuse = 0;
    }

    private void ResetBox()
    {
        slotUI.SetActive(false);
        fuseSelectionUI.SetActive(false);
        fuseBoxAnimator.SetTrigger("FuseBoxClose");
        interactPanelBool = true;

        for (int i = 0; i < fuseSlots.Length; i++)
        {
            if (resetBoxNum == 3 && i == 0)
            {
                continue;
            }

            if (resetBoxNum == 2 && i == 1)
            {
                continue;
            }

            if (resetBoxNum == 4 && i == 2)
            {
                continue;
            }

            if (resetBoxNum == 1 && i == 3)
            {
                continue;
            }

            if (fuseSlots[i].slotPosition1.childCount > 0)
            {
                Destroy(fuseSlots[i].slotPosition1.GetChild(0).gameObject);
                Destroy(fuseSlots[i].slotPosition2.GetChild(0).gameObject);
            }

            if (fuseSlots[i].occupied == true)
            {
                int tempNum = fuseSlots[i].fuseOccupying;
                fusePrefabs[tempNum - 1].fuseSelectionButton.GetComponent<Button>().interactable = true;
            }
        }

        boxCollider.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerController.state = PlayerController.State.free;

        if(fusePuzzleCompletion == 1)
        {
            AudioManager.instance.PlaySound("PAactivated", centralHub.position, true);
            AudioManager.instance.PlaySound("elevator1", centralHub.position, true);
        }

        if (fusePuzzleCompletion == 2)
        {
            AudioManager.instance.PlaySound("PAcommencing", centralHub.position, true);
            AudioManager.instance.PlaySound("elevator2", centralHub.position, true);
        }

        if (fusePuzzleCompletion == 3)
        {
            AudioManager.instance.PlaySound("PAdescending", centralHub.position, true);
            AudioManager.instance.PlaySound("elevator3", centralHub.position, true);
        }

        if (fusePuzzleCompletion == 4)
        {
            AudioManager.instance.PlaySound("PAarriving", centralHub.position, true);
            AudioManager.instance.PlaySound("elevator4", centralHub.position, true);
            elevatorDoor.SetTrigger("doorOpen");
        }

        this.gameObject.GetComponent<FusePuzzleBehavior>().enabled = false;
    }
}
