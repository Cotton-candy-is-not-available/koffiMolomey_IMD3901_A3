using System.Globalization;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PickupScript : NetworkBehaviour
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

    //------------------ Picking up -------------------

    public void pickupObject(GameObject obj)
    {
        if (!IsOwner) return; //only the player controlling this can request pickup

        NetworkObject netObj = obj.GetComponent<NetworkObject>(); //get the network object of the obj
        if (netObj == null)
        {
            return;//if null return and do nothing so no error
        }
        pickupObjectServerRpc(netObj.NetworkObjectId, OwnerClientId); //ask server to pick it up with RPC



        ////obj.transform.localPosition = new Vector3(holdArea.transform.position.x, holdArea.transform.position.y, obj.transform.localPosition.z);
        ////obj.transform.rotation = Quaternion.identity;//might need to chnage or remove
        //if (obj.GetComponent<Rigidbody>())
        //{
        //    Debug.Log("picking up");
        //    heldObjRB = obj.GetComponent<Rigidbody>();
        //    heldObjRB.useGravity = false;//prevents object from falling
        //    heldObjRB.linearDamping = 10;
        //    heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;//prevents object from rotating

        //    heldObjRB.isKinematic = true;//prevents object from moving when hitting other objects in the scene

        //    heldObjRB.transform.parent = holdArea;//parent object to camera space so it can follow the camera

        //    holdArea.transform.localScale = new Vector3(smallScale, smallScale, smallScale);//make heldObj and hold area smaller when held

        //    heldObjRB.transform.position = holdArea.position;//move object to hold area positon

        //    heldObj = obj;

        //}



    }

    [ServerRpc(RequireOwnership = false)]
    public void pickupObjectServerRpc(ulong objectId, ulong playerClientId)
    {
        //get objects's network object from servers list of spawned objects
        NetworkObject netObj = NetworkManager.Singleton.SpawnManager.SpawnedObjects[objectId];

        //give client ownership so that they can parent
        netObj.ChangeOwnership(playerClientId); //give client ownership access

        //parent object to player hold area
        netObj.transform.SetParent(NetworkManager.Singleton.ConnectedClients[playerClientId].PlayerObject.transform);
        
        assignHeldObjectClientRpc(netObj.NetworkObjectId);

    }

    [ClientRpc]
    void assignHeldObjectClientRpc(ulong objectId)
    {
        NetworkObject netObj = NetworkManager.Singleton.SpawnManager.SpawnedObjects[objectId];
        heldObj = netObj.gameObject;
        heldObjRB = heldObj.GetComponent<Rigidbody>();//get rigid body

        //place object in hold area
        //heldObj.transform.position = holdArea.position;
        //heldObj.transform.rotation = holdArea.rotation;

        if (heldObjRB != null)
        {
            heldObjRB.useGravity = false; //turn gravity off so doesnt fall
            heldObjRB.linearDamping = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;//prevents object from rotating

            //heldObjRB.isKinematic = true;//prevents object from moving when hitting other objects in the scene

            //heldObjRB.transform.parent = holdArea;//parent object to camera space so it can follow the camera

            holdArea.transform.localScale = new Vector3(smallScale, smallScale, smallScale);//make heldObj and hold area smaller when held

            heldObjRB.transform.position = holdArea.position;//move object to hold area positon
        }
    }


    //------------------ Dropping -------------------
    public void dropObject(GameObject obj)
    {
        Debug.Log("Drop");

        if (!IsOwner) return;
        if (heldObj == null) return;

        NetworkObject netObj = heldObj.GetComponent<NetworkObject>(); //get network object of heldObj

        //heldObjRB.useGravity = true;//let the item fall
        //heldObjRB.constraints = RigidbodyConstraints.None;//prevents object rotation

        //heldObjRB.isKinematic = false;

        holdArea.transform.localScale = new Vector3(defaultScale, defaultScale, defaultScale); ;//bring hold area and heldObj back to original size for the next object

        if (netObj != null)
        {
            DropObjectServerRpc(netObj.NetworkObjectId);
        }

        //clear local reference
        heldObj = null;
        heldObjRB = null;

        //heldObjRB.linearDamping = 1;
        //heldObjRB.constraints = RigidbodyConstraints.None;//prevents object rotation

        //heldObjRB.isKinematic = false;

        //holdArea.transform.localScale = new Vector3(defaultScale, defaultScale, defaultScale); ;//bring hold area and heldObj back to original size for the next object
        ////obj.transform.parent = null;

        //heldObjRB.transform.parent = null;//unfreeze transformations and unparent


        //heldObj = null;//hand is now empty

    }


    [ServerRpc(RequireOwnership = false)]
    void DropObjectServerRpc(ulong objectId)
    {
        NetworkObject netObj = NetworkManager.Singleton.SpawnManager.SpawnedObjects[objectId];

        //unparent the object
        netObj.transform.SetParent(null);

        Rigidbody rb = netObj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            //clear the rigidbody's attributes
            rb.useGravity = true; //enable gravity again
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None; //allow full movement
        }
        ClearHeldObjectClientRpc();

    }


   [ClientRpc]
   void ClearHeldObjectClientRpc()
   {
    //reset the held object from the client
    heldObj = null;
    heldObjRB = null;
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
            Debug.Log("Moving");

            //Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            //heldObjRB.AddForce(moveDirection * pickupForce);

            heldObj.transform.position = holdArea.position;
        
    }
}
