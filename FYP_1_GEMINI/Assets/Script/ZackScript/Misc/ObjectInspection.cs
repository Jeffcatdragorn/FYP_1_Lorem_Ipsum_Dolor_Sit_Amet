using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInspection : MonoBehaviour
{
    private float SceneWidth;
    private Vector2 PressPoint;
    private Quaternion StartRotation;
    public bool type;
    public bool check;
    public float rotationSpeed;
    public float timer = 3f;
    public PlayerController playerController;
    public GameObject inspectUI;
    public GameObject inspectCamera;

    [SerializeField] HumanoidLandInput input;
    [SerializeField] GameObject flashlightTutorialPanel;
    [SerializeField] GameObject tabletTutorialPanel;

    private void Start()
    {
        SceneWidth = Screen.width;
        Debug.Log(SceneWidth);
        //StartRotation = transform.rotation;
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (input.FlashlightIsPressed == true)
            {
                if (TutorialManager.inspectStop == false)
                {
                    inspectUI.SetActive(false);
                    playerController.enabled = true;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    inspectCamera.SetActive(false);
                }
            }
            else
            {
                playerController.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        //else
        //{
        //    playerController.enabled = true;
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //}

        if (input.ShootIsPressed == true && check == false)
        {
            PressPoint = Mouse.current.position.ReadValue();
            StartRotation = transform.rotation;
            check = true;
        }

        else if (input.ShootIsPressed == true && check == true) {
            float CurrentDistanceBetweenMousePositionsX = (Mouse.current.position.ReadValue() - PressPoint).x;
            float CurrentDistanceBetweenMousePositionsY = (Mouse.current.position.ReadValue() - PressPoint).y;
            transform.rotation = StartRotation * Quaternion.Euler(Vector3.down * (CurrentDistanceBetweenMousePositionsX / SceneWidth) * rotationSpeed)
                                               * Quaternion.Euler(Vector3.right * (CurrentDistanceBetweenMousePositionsY / SceneWidth) * rotationSpeed); ;
        }

        if(input.ShootIsPressed == false && check == true)
        {
            check = false;
        }
    }
}
