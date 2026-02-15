using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{

    public float interactRange = 5f;
    public Camera playerCamera;

    public Crosshair crosshair;
    public PickupScript pickup;


    public GameObject box;
    public GameObject pos;


    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            if (hit.collider.CompareTag("Interactable"))//if collider has hit an object with interactble tag
            {
                crosshair.setInteract(true);//calling to create rollover effect


                if (Keyboard.current.eKey.wasPressedThisFrame)//press e to grab and drop object
                {
                    if (pickup.heldObj == null)//if hand is empty
                    {
                        //pickup object
                        pickup.pickupObject(hit.transform.gameObject, gameObject);//call pickup fucntion

                    }
                    else//if hand is not empty
                    {
                        //Drop object
                        pickup.dropObject(hit.transform.gameObject);//call drop function

                    }

                }
                if (pickup.heldObj != null)//if there is an object picked up
                {
                    //moveObject
                    pickup.moveObject();//call move function

                    if (Mouse.current.leftButton.wasPressedThisFrame)
                    {
                        pickup.throwObject();//call move function
                    }
                }

                if(Keyboard.current.iKey.wasPressedThisFrame)
                {
                    var instance = Instantiate(box, pos.transform);
                    var instanceNetworkObject = instance.GetComponent<NetworkObject>();
                    instanceNetworkObject.Spawn();
                }



                return;
            }


        }

        crosshair.setInteract(false);
    }


















    }
