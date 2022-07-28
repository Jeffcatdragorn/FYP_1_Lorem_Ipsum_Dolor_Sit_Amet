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

    [SerializeField] HumanoidLandInput input;

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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (input.ShootIsPressed == true && check == false)
        {
            PressPoint = Mouse.current.position.ReadValue();
            StartRotation = transform.rotation;
            check = true;
        }

        else if (input.ShootIsPressed == true && check == true) {
            float CurrentDistanceBetweenMousePositionsX = (Mouse.current.position.ReadValue() - PressPoint).x;
            float CurrentDistanceBetweenMousePositionsY = (Mouse.current.position.ReadValue() - PressPoint).y;
            transform.rotation = StartRotation * Quaternion.Euler(Vector3.down * (CurrentDistanceBetweenMousePositionsX / SceneWidth) * 360)
                                               * Quaternion.Euler(Vector3.back * (CurrentDistanceBetweenMousePositionsY / SceneWidth) * 360); ;
        }

        if(input.ShootIsPressed == false && check == true)
        {
            check = false;
        }
    }
}
