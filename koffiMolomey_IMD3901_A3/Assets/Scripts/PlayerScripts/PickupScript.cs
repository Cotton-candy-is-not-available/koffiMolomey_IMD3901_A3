using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PickupScript : MonoBehaviour
{
    [SerializeField] Transform holdArea; //will be parented to this

    //the object that is picked up
    public GameObject heldObj;
    private Rigidbody heldObjRB;

    //physics
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;


    //picked up and normal scales
    float defaultScale = 1f;
    float smallScale = 0.5f;


    //----- For throwing trgectory: Beer Pong---
    //For objects that need to be thrown
    public float throwForce = 500f;
 
    //------------------------------------------

   
    private void Update()
    {

        ////PICKING UP-----------------------------
        //if (Keyboard.current.iKey.wasPressedThisFrame) //if i was pressed to pick up
        //{
        //    Debug.Log("i was presssed to pickup object");

        //    if (heldObj == null) //if an object is NOT already being held
        //    {
        //        RaycastHit hit;
        //        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
        //        {
        //            //pick up the object
        //            pickupObject(hit.transform.gameObject);
        //        }
        //    }
        //}

        ////DROPPING-----------------------------
        //if (Keyboard.current.iKey.wasPressedThisFrame && heldObj != null) //if tab was pressed to drop
        //{
        //    Debug.Log("tab was presssed to drop object");
        //    dropObject();
        //}

        ////MOVING-----------------------------
        //if (heldObj != null) //if an object is currently being held
        //{
        //    //move the object around
        //    moveObject();
          
        //}

        
    }

    /*----------------FUNCTIONS---------------*/
    //[ServerRpc(RequireOwnership = false)]
    public void pickupObject(GameObject obj, GameObject player)
    {
        obj.transform.parent = holdArea.transform;
        if (obj.GetComponent<Rigidbody>())
        {
            heldObjRB = obj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;//prevents object from falling
            heldObjRB.linearDamping = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;//prevents object from rotating
            //heldObjRB.constraints = RigidbodyConstraints.FreezeRotationY;//prevents object from rotating
            //heldObjRB.constraints = RigidbodyConstraints.FreezeRotationZ;//prevents object from rotating

            heldObjRB.isKinematic = true;//prevents object from moving when hitting other objects in the scene

            //heldObjRB.transform.parent = holdArea;//parent object to camera space so it can follow the camera

            holdArea.transform.localScale = new Vector3(smallScale, smallScale, smallScale);//make heldObj and hold area smaller when held

            heldObjRB.transform.position = holdArea.position;//move object to hold area positon

            heldObj = obj;

        }



    }


    public void dropObject(GameObject obj)
    {

        heldObjRB.useGravity = true;//let the item fall
        heldObjRB.linearDamping = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;//prevents object rotation

        heldObjRB.isKinematic = false;

        holdArea.transform.localScale = new Vector3(defaultScale, defaultScale, defaultScale); ;//bring hold area and heldObj back to original size for the next object
        obj.transform.parent = null;

        //heldObjRB.transform.parent = null;//unfreeze transformations and unparent


        heldObj = null;//hand is now empty

    }


    public void throwObject()
    {
        heldObjRB.useGravity = true;//let the item fall
        heldObjRB.linearDamping = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;// object can rotate again

        heldObjRB.isKinematic = false;

        holdArea.transform.localScale = new Vector3(defaultScale, defaultScale, defaultScale); ;//bring hold area and heldObj back to original size for the next object

        heldObjRB.transform.parent = null;//unfreeze transformations and unparent

        heldObjRB.AddForce(transform.forward * throwForce);//throws object when dropped and unparented

        heldObj = null;//hand is now empty


    }

    public void moveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }
}
