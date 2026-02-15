using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkConnect : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    public void Create()//create a session
    {
        NetworkManager.Singleton.StartHost();//same as cliquing button in inspector
        hideCanvas(canvas);//hide the canvas after clicking
    }

    public void Join()//join session
    {
        NetworkManager.Singleton.StartClient();//same as cliquing button in inspector
        hideCanvas(canvas);//hide the canvas after clicking

    }

    private void hideCanvas(GameObject canvas)
    {
        canvas.SetActive(false);
    }

   



}
