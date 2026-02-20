using Unity.Netcode;
using Unity.Networking.Transport;
using UnityEngine;

public class CustomNetworkManger : NetworkManager
{
    GameObject playerPrefab;
    Transform playerSpawnPos;
    public virtual void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        //var player = (GameObject)GameObject.Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
        //NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

        Debug.Log("Player added");


    }



}
