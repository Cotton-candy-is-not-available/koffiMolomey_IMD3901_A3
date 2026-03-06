using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GraphicRaycasterUI : MonoBehaviour
{
    public GraphicRaycaster m_Raycaster;

    public Canvas canvas;

    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    public Button P1StartButton;
    public Button P2StartButton;

    public Button PvPButton;
    public Button coopButton;

    public buttonFunctions getButtonFunctions;


    public gameManager GameManager;

    void Start()
    {
        ////Fetch the Raycaster from the GameObject (the Canvas)
        //m_Raycaster = GetComponent<GraphicRaycaster>();
        ////Fetch the Event System from the Scene
        //m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        //if (canvas.worldCamera!= null)
        //{
        //    if (Mouse.current == null) return;
        //    {
        //        m_PointerEventData = new PointerEventData(EventSystem.current);

        //        //set the Pointer Event Position to that of the mouse position
        //        m_PointerEventData.position = new Vector2(Screen.width / 2f, Screen.height / 2f);

        //        //create a list of Raycast Results
        //        List<RaycastResult> results = new List<RaycastResult>();

        //        //raycast using the Graphics Raycaster and mouse click position
        //        m_Raycaster.Raycast(m_PointerEventData, results);

                //for every object hit by the raycast on the canvas, output the name of the game object
                //foreach (RaycastResult result in results)
                //{
                    //if (startButton)//if the start button was hit 
                    //{
                    //    //startButton.onClick.AddListener(startGame);//start the game
                    //    EventSystem.current.SetSelectedGameObject(startButton.gameObject, new BaseEventData(EventSystem.current));
                    //}
                    //if (PvPButton)//if the PvP button was hit
                    //{
                    //    EventSystem.current.SetSelectedGameObject(PvPButton.gameObject, new BaseEventData(EventSystem.current));
                    //}
                    //if (coopButton)//if the coopButton was hit
                    //{
                    //    EventSystem.current.SetSelectedGameObject(coopButton.gameObject, new BaseEventData(EventSystem.current));

                    //}

                    //if (Mouse.current.leftButton.wasPressedThisFrame)//if left mouse button was pressed
                    //{
                    //    Debug.Log("Clicked " + result.gameObject.name);

                    //    if (P1StartButton)//if the start button was hit 
                    //    {
                    //        //startButton.onClick.AddListener(getButtonFunctions.readyPlayer);//start the game
                    //        ExecuteEvents.Execute(P1StartButton.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);//make button turn to pressed colour onClick
                    //    }
                    //    if (P2StartButton)//if the start button was hit 
                    //    {
                    //        //P2StartButton.onClick.AddListener(getButtonFunctions.readyPlayer(P2StartButton);//start the game
                    //        ExecuteEvents.Execute(P2StartButton.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);//make button turn to pressed colour onClick
                    //    }
                        
                        
                    //    if (PvPButton)//if the PvP button was hit
                    //    {
                    //        PvPButton.onClick.RemoveListener(getButtonFunctions.PvPMode);//PvP mode function
                    //        PvPButton.onClick.AddListener(getButtonFunctions.PvPMode);//PvP mode function
                    //        ExecuteEvents.Execute(PvPButton.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);//make button turn to pressed colour onClick
                    //    }
                    //    if (coopButton)//if the coopButton was hit
                    //    {
                    //        coopButton.onClick.RemoveListener(getButtonFunctions.coopMode);//coop mode function
                    //        coopButton.onClick.AddListener(getButtonFunctions.coopMode);//coop mode function
                    //        ExecuteEvents.Execute(coopButton.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);//make button turn to pressed colour onClick

                    //    }

                        //if (result.gameObject.name == "StartButton")//if the start button was clicked
                        //{
                        //    //start the countdown
                        //    //    countDownObject.startCountDown(timeIsOver);//start the count down and keep it running as long as timeIsOver is false
                        //    Debug.Log("Game started");
                        //}

        //            }


        //        }
               
        //    }
        //}
        //if (GameManager.playerCounter > 1 && canvas.worldCamera == null)//if there is one player and the cameras are null, look for even cameras on the players
        //{
            

        //    canvas.worldCamera = GameObject.FindGameObjectWithTag("P1Camera").GetComponent<Camera>();//assign event camera of P1 start canvas as player 1's camera
        //    //canvas.worldCamera = GameObject.FindGameObjectWithTag("P2Camera").GetComponent<Camera>();//assign event camera of P2 start canvas as player 2's camera
        //    Debug.Log("Got P1 camera");
        //    //Debug.Log("Got P2 camera");
        //}
        //add crosshair script
        //crosshair.setInteract(true);//calling to create rollover effect
    }





}
