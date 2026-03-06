using Unity.Netcode;
using UnityEngine;

public class assignScripts : NetworkBehaviour
{

    public static assignScripts assigner;

    public GameObject playerPrefab;
    public NetworkObject player1Prefab;

    public NetworkObject player2Prefab;



    public Canvas PvPCanvas;

    private void Awake()
    {
        if (assigner == null) { 
        
            assigner = this;
        
        }
    }


    public override void OnNetworkSpawn()
    {
        //get the network object of each player
        NetworkObject netObj = GetComponent<NetworkObject>();

        if (netObj.OwnerClientId == 0)
        {
            player1Prefab = netObj; //host
            Debug.Log("player1 net spawn");
        }
        else if (netObj.OwnerClientId == 1)
        {
            player2Prefab = netObj; //client
            Debug.Log("player2 net spawn");

        }
    }

    void Update()
    {
        if (playerPrefab != null)
        {
            //PvPCanvas.worldCamera = player1Prefab.GetComponent<PlayerController>().PcCamera;
            //PvPCanvas.worldCamera = player2Prefab.GetComponent<PlayerController>().PcCamera;

            PvPCanvas.worldCamera = playerPrefab.GetComponent<PlayerController>().PcCamera;

        }
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
