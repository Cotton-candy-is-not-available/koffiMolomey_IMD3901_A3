using System;
using UnityEngine;
using UnityEngine.UI;

public class basketCollision : MonoBehaviour
{
   [SerializeField] gameManager manager;

    public bool fabricBool = false;
    public bool trimBool = false;
    public bool threadBool = false;

    public String fabricName;
    public String trimName;
    public String threadName;


    private void OnCollisionStay(Collision collision)
    {
        switch (collision.gameObject.layer) {

            case 7://collided with something on fabric layer
                fabricBool = true;
                fabricName = collision.gameObject.name;//get name of fabric

                Debug.Log("collided with fabric: " + fabricName);
                break;

            case 8://collided with something on trim layer
                trimBool = true;
                trimName = collision.gameObject.name;//get name of trim
                Debug.Log("collided with trim: " + trimName);
                break;

            case 9://collided with something on thread layer
                threadBool = true;
                threadName = collision.gameObject.name;//get name of thread
                Debug.Log("collided with thread: " + threadBool);
                break;

        }

        if (manager.timeIsOver == true)
        {
            collision.gameObject.tag ="Untagged";//turn tag to default so that they cannot be interacted with anymore
            //Make sure tags are interactable in start/spawn
        }




    }

    private void OnCollisionExit(Collision collision)
    {
        switch (collision.gameObject.layer)
        {

            case 7://collided with something on fabric layer
                fabricBool = false;
                fabricName = null;//there is no fabric in the basket anymore
                Debug.Log("No longer collided with fabric");
                break;

            case 8://collided with something on trim layer
                trimBool = false;
                trimName = null;//there is no trim in the asket anymore
                Debug.Log("No longer collided with trim");
                break;

            case 9://collided with something on thread layer
                threadBool = false;
                threadName = null;//there is not thread in the basket anymore
                Debug.Log(" No longer collided with thread");
                break;

        }
    }



}
