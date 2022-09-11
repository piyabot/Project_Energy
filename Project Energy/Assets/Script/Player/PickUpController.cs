using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRB;

    [SerializeField] private float pickupRange = 8.0f;
    [SerializeField] private float pickupForce = 150.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(heldObj == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }
        if (heldObj != null)
        {
            MoveObject();
        }
    }

    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.velocity = Vector3.zero;
            heldObjRB.angularVelocity = Vector3.zero;
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            //heldObjRB.constraints = RigidbodyConstraints.FreezePosition;
            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }

    void DropObject()
    {
            heldObjRB.useGravity = true;
            heldObjRB.drag = 1;
            //heldObjRB.constraints = RigidbodyConstraints.FreezePosition;
            heldObjRB.transform.parent = null;
            heldObj = null;
    }
}
