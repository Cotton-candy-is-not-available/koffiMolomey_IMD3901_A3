using UnityEngine;

public class assignScripts : MonoBehaviour
{
    // Update is called once per frame

    public GameObject player1Prefab;

    public GameObject player2Prefab;

    public Canvas PvPCanvas;


    void Update()
    {
        //if()
        //PvPCanvas.worldCamera = GameObject.FindGameObjectWithTag("P1Camera").GetComponent<Camera>();//assign event camera of P1 start canvas as player 1's camera


        //if (GameManager.playerCounter >= 1 && canvas.worldCamera == null)//if there is one player and the cameras are null, look for even cameras on the players
        //{
        //    canvas.worldCamera = GameObject.FindGameObjectWithTag("P1Camera").GetComponent<Camera>();//assign event camera of P1 start canvas as player 1's camera
        //    //canvas.worldCamera = GameObject.FindGameObjectWithTag("P2Camera").GetComponent<Camera>();//assign event camera of P2 start canvas as player 2's camera
        //    Debug.Log("Got P1 camera");
        //    //Debug.Log("Got P2 camera");

        //}
    }
}
