using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    [SerializeField] float pickUpRange = 5f;
    [SerializeField] float moveForce = 255f;
    [SerializeField] Transform holdParent;
    [SerializeField] GameObject heldObject;
    [SerializeField] HumanoidLandInput input;
    [SerializeField] float pickUpCooldownCounter = 0.0f;
    [SerializeField] float pickUpCooldown = 1.0f;
    [SerializeField] bool pickUpCheck = false;
    [SerializeField] LayerMask pickUpObjectLayer;

    void Update()
    {

        SetPickUpCooldown();
        if (input.PickUpObjectIsPressed && pickUpCheck == false)
        {

            if (heldObject == null && pickUpCooldownCounter == 0.0f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange, pickUpObjectLayer))
                {
                    PickUpObject(hit.transform.gameObject);
                }
                pickUpCooldownCounter = pickUpCooldown;
            }

            else
            {
                DropObject();
            }
        }

        if(heldObject != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObject.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObject.transform.position);
            heldObject.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickUpObject(GameObject pickedObj)
    {
        if (pickedObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickedObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObject = pickedObj;
        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObject.GetComponent<Rigidbody>();
        heldRig.GetComponent<Rigidbody>().useGravity = true;
        heldRig.drag = 1;

        heldObject.transform.parent = null;
        heldObject = null;
    }

    void SetPickUpCooldown()
    {
        if (pickUpCooldownCounter > 0)
        {
            pickUpCooldownCounter -= Time.deltaTime;
        }

        if (pickUpCooldownCounter <= 0)
        {
            pickUpCooldownCounter = 0.0f;
        }
    }
}
