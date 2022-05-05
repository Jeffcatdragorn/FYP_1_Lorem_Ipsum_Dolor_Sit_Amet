using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterController controller;
    public Transform cam;

    public float moveSpeed =3f;
    public float turnSpeedSmooth = 0.1f;
    public float turnVelocity;
    public float angle;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.z > 0.0f)
        {
            Debug.Log("1");
            float targetAngle = Mathf.Atan2(direction.x, direction.x) * Mathf.Rad2Deg/* + cam.eulerAngles.y*/;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSpeedSmooth);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

        if (direction.z < 0.0f)
        {
            Debug.Log("2");
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg/* + cam.eulerAngles.y*/;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSpeedSmooth);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.back;
            transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

        if (direction.x > 0.0f)
        {
            Debug.Log("3");
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg/* + cam.eulerAngles.y*/;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSpeedSmooth);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.left;
            transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

        if (direction.x < 0.0f)
        {
            Debug.Log("4");
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg/* + cam.eulerAngles.y*/;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSpeedSmooth);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.right;
            transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}