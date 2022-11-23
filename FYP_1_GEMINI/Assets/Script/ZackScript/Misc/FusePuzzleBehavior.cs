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
    [SerializeField] GameObject elevatorDoor;
    [SerializeField] bool uiActive = false;
    [SerializeField] bool interactPanelBool = false;

    private float cooldownTimer;

    bool reset = false;

    //[SerializeField] GameObject prisonFuse, labFuse, generalFuse, generatorFuse;

    private void Awake()
    {
        selectedFuse = 0;
    }

    private void Update()
    {
        Debug.Log(fusePuzzleCompletion);

        if (reset == true)
        {
            for (int i = 0; i < fuseSlots.Length; i++)
            {
                if (fuseSlots[i].slotPosition1.childCount > 0)
                {
                    Destroy(fuseSlots[i].slotPosition1.GetChild(0).gameObject);
                    Destroy(fuseSlots[i].slotPosition2.GetChild(0).gameObject);
                }

                if (i < 4)
                {
                    fusePrefabs[i].fuseSelectionButton.GetComponent<Button>().interactable = true;
                }

                fuseSlots[i].occupied = false;

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

        if (fusePuzzleCompletion == 4)
        {
            elevatorDoor.SetActive(false);
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

                        FusePuzzleBehavior.fusePuzzleCompletion += 1;
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
                    }

                    fusePrefabs[selectedFuse - 1].fuseSelectionButton.GetComponent<Button>().interactable = false;
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

                        FusePuzzleBehavior.fusePuzzleCompletion += 1;
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
                    }

                    fusePrefabs[selectedFuse - 1].fuseSelectionButton.GetComponent<Button>().interactable = false;
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

                        FusePuzzleBehavior.fusePuzzleCompletion += 1;
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
                    }

                    fusePrefabs[selectedFuse - 1].fuseSelectionButton.GetComponent<Button>().interactable = false;
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

                        FusePuzzleBehavior.fusePuzzleCompletion += 1;
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
                    }

                    fusePrefabs[selectedFuse - 1].fuseSelectionButton.GetComponent<Button>().interactable = false;
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
                }

                fusePrefabs[selectedFuse - 1].fuseSelectionButton.GetComponent<Button>().interactable = false;
                fuseSlots[i - 1].occupied = true;
                selectedFuse = 0;
            }
        }
    }

    public void ResetSlots()
    {
        reset = true;

        selectedFuse = 0;

        fusePuzzleCompletion = 0;

        lightSphere1.GetComponent<MeshRenderer>().material = lightSphereNormalMaterial;
        lightSphere2.GetComponent<MeshRenderer>().material = lightSphereNormalMaterial;

    }
}
