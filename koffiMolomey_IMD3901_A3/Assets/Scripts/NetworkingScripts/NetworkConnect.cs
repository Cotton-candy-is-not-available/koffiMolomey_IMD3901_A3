using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkConnect : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject modePanel;

    public void Create()//create a session
    {
        NetworkManager.Singleton.StartHost();//same as cliquing button in inspector
        startPanel.SetActive(false);//hide the panel after clicking
        modePanel.SetActive(true);//show the panel after clicking
    }

    public void Join()//join session
    {
        NetworkManager.Singleton.StartClient();//same as cliquing button in inspector
        startPanel.SetActive(false);//hide the panel after clicking
        modePanel.SetActive(true);//show the panel after clicking

    }





}
