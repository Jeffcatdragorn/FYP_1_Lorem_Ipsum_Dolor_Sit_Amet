using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    [SerializeField] float pickUpRange = 5f;
    [SerializeField] float moveForce = 255f;
    [SerializeField] Transform holdSmallParent;
    [SerializeField] Transform holdBigParent;

    [SerializeField] GameObject heldObject;
    [SerializeField] HumanoidLandInput input;
    [SerializeField] float pickUpCooldownCounter = 0.0f;
    [SerializeField] float pickUpCooldown = 1.0f;
    [SerializeField] LayerMask pickUpObjectLayer;
    [SerializeField] float moveSpeed;

    void Update()
    {
        SetPickUpCooldown();
        if (input.PickUpObjectIsPressed && pickUpCooldownCounter == 0.0f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange, pickUpObjectLayer))
            {
                if (heldObject == null)
                {
                    PickUpObject(hit.transform.gameObject);
                    pickUpCooldownCounter = pickUpCooldown;
                }

                else
                {
                    DropObject();
                    pickUpCooldownCounter = pickUpCooldown;
                }
            }

        }
        if (heldObject != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if (heldObject.tag == "tile")
        {
            Debug.Log("Moveing");
            //heldObject.transform.position = holdBigParent.transform.position;
            //heldObject.transform.rotation = holdBigParent.transform.rotation;


            if (Vector3.Distance(heldObject.transform.position, holdBigParent.position) > 0.1f)
            {
                Vector3 moveDirection = (holdBigParent.position - heldObject.transform.position);
                heldObject.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
                // Vector3.Lerp(heldObject.transform.position, holdBigParent.transform.position, moveSpeed);
            }
            //else
            //{
            //    heldObject.transform.position = holdBigParent.position;
            //}
        }

        else
        {
            if (Vector3.Distance(heldObject.transform.position, holdSmallParent.position) > 0.1f)
            {
                Vector3 moveDirection = (holdSmallParent.position - heldObject.transform.position);
                heldObject.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
            }
        }
    }

    void PickUpObject(GameObject pickedObj)
    {
        if (pickedObj.GetComponent<Rigidbody>())
        {
            if(pickedObj.tag == "tile")
            {
                Rigidbody objRig = pickedObj.GetComponent<Rigidbody>();
                objRig.useGravity = false;
                objRig.drag = 10;
                objRig.constraints = RigidbodyConstraints.FreezeRotation;
                objRig.isKinematic = false;

                //pickedObj.transform.parent = holdBigParent;
                heldObject = pickedObj;
            }

            else
            {
                Rigidbody objRig = pickedObj.GetComponent<Rigidbody>();
                objRig.useGravity = false;
                objRig.drag = 10;
                objRig.constraints = RigidbodyConstraints.FreezeRotation;
                objRig.isKinematic = false;

                pickedObj.transform.parent = holdSmallParent;
                heldObject = pickedObj;
            }
        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObject.GetComponent<Rigidbody>();
        heldRig.GetComponent<Rigidbody>().useGravity = true;
        heldRig.drag = 1;
        heldRig.constraints = RigidbodyConstraints.None;
        heldRig.isKinematic = false;

        heldObject.transform.parent = null;
        heldObject = null;
    }

    public void LetGoOfObject()
    {
        //Rigidbody heldRig = heldObject.GetComponent<Rigidbody>();
        //heldRig.drag = 1;
        //heldRig.constraints = RigidbodyConstraints.None;

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
