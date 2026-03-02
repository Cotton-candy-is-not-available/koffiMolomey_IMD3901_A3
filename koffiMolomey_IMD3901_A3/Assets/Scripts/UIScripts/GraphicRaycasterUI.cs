using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GraphicRaycasterUI : MonoBehaviour
{
    public GraphicRaycaster m_Raycaster;

    public Canvas m_Canvas;

    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    public gameManager GameManager;

    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        if (m_Canvas.worldCamera!= null)
        {
            if (Mouse.current == null) return;
            {
                m_PointerEventData = new PointerEventData(EventSystem.current);

                //set the Pointer Event Position to that of the mouse position
                m_PointerEventData.position = new Vector2(Screen.width / 2f, Screen.height / 2f);

                //create a list of Raycast Results
                List<RaycastResult> results = new List<RaycastResult>();

                //raycast using the Graphics Raycaster and mouse click position
                m_Raycaster.Raycast(m_PointerEventData, results);

                //for every object hit by the raycast on the canvas, output the name of the game object
                foreach (RaycastResult result in results)
                {
                    
                    if (Mouse.current.leftButton.wasPressedThisFrame)//if left mouse button was pressed
                    {
                        //string clickedButtonName = result.gameObject.name;
                        Debug.Log("Clicked " + result.gameObject.name);

                        if (result.gameObject.name == "StartButton")//if the start button was clicked
                        {
                            //start the countdown
                            //    countDownObject.startCountDown(timeIsOver);//start the count down and keep it running as long as timeIsOver is false
                            Debug.Log("Game started");
                        }

                    }


                }
               
            }
        }
        if (GameManager.playerCounter >= 1 &&  m_Canvas.worldCamera)//if there is one player and the cameras are null, look for even cameras on the players
        {
            m_Canvas.worldCamera = GameObject.FindGameObjectWithTag("P1Camera").GetComponent<Camera>();//assign event camera of P1 start canvas as player 1's camera
            //m_Canvas.worldCamera = GameObject.FindGameObjectWithTag("P2Camera").GetComponent<Camera>();//assign event camera of P2 start canvas as player 2's camera
            Debug.Log("Got P1 camera");
            //Debug.Log("Got P2 camera");

        }
        //add crosshair script
    }
}
