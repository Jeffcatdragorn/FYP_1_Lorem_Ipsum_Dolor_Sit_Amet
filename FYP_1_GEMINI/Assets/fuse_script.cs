using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuse_script : MonoBehaviour
{
    public enum FuseBox
    {
        prison, lab, general, generator,
    }

    [System.Serializable]
    public class FuseSlot
    {
        public Transform slotPosition;
        public Button slotButton;
        public bool occupied;
    }

    [System.Serializable]
    public class FusePrefab
    {
        public GameObject normal;
        public GameObject glow;
    }

    public static int selectedFuse;

    [SerializeField] HumanoidLandInput input;
    [SerializeField] GameObject player;
    [SerializeField] FuseBox thisFuseBox;
    [SerializeField] GameObject interactPanel;
    [SerializeField] GameObject lightSphere;
    [SerializeField] Material lightSphereGlowMaterial;
    [SerializeField] FuseSlot[] fuseSlots;
    [SerializeField] FusePrefab[] fusePrefabs;

    //[SerializeField] GameObject prisonFuse, labFuse, generalFuse, generatorFuse;

    private void Update()
    {
        if(this.gameObject.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "playerFront")
        {
            interactPanel.SetActive(true);
            if (input.InteractIsPressed == true)
            {
                
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
        if(i == 1)
        {
            if (fuseSlots[i - 1].occupied == false)
            {
                if (selectedFuse == 3 && this.thisFuseBox == FuseBox.general)
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;
                    lightSphere.GetComponent<MeshRenderer>().material = lightSphereGlowMaterial;
                }

                else if (selectedFuse == 3)
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;
                }

                else
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;
                }

                fuseSlots[i - 1].occupied = true;
            }
        }

        if (i == 2)
        {
            if (fuseSlots[i - 1].occupied == false)
            {
                if (selectedFuse == 2 && this.thisFuseBox == FuseBox.lab)
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;
                    lightSphere.GetComponent<MeshRenderer>().material = lightSphereGlowMaterial;
                }

                else if (selectedFuse == 2)
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;
                }
                else
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;
                }

                fuseSlots[i - 1].occupied = true;
            }
        }

        if (i == 3)
        {
            if (fuseSlots[i - 1].occupied == false)
            {
                if (selectedFuse == 4 && this.thisFuseBox == FuseBox.generator)
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;
                    lightSphere.GetComponent<MeshRenderer>().material = lightSphereGlowMaterial;
                }

                else if (selectedFuse == 4)
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;
                }
                else
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;
                }

                fuseSlots[i - 1].occupied = true;
            }
        }

        if (i == 4)
        {
            if (fuseSlots[i - 1].occupied == false)
            {
                if (selectedFuse == 1 && this.thisFuseBox == FuseBox.prison)
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;
                    lightSphere.GetComponent<MeshRenderer>().material = lightSphereGlowMaterial;
                }

                else if (selectedFuse == 1)
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].glow);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;
                }
                else
                {
                    GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                    newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                    newPrefab.transform.localPosition = Vector3.zero;
                    newPrefab.transform.localScale = Vector3.one;
                }

                fuseSlots[i - 1].occupied = true;
            }
        }

        if (i == 5)
        {
            if (fuseSlots[i - 1].occupied == false)
            {
                GameObject newPrefab = Instantiate(fusePrefabs[selectedFuse - 1].normal);
                newPrefab.transform.parent = fuseSlots[i - 1].slotPosition.transform;
                newPrefab.transform.localPosition = Vector3.zero;
                newPrefab.transform.localScale = Vector3.one;
            }
        }
    }

    public void ResetSlots()
    {

    }
}

