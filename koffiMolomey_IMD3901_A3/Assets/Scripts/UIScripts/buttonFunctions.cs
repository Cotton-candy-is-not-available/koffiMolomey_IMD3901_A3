using Unity.Netcode;
using UnityEngine;

public class buttonFunctions : MonoBehaviour
{
    public GameObject gameModeCanvas;

    public GameObject P1Items;

    public GameObject P2Items;

    public GameObject sharedBasket;
    public GameObject sharedChecklist;

    public int playerReadyCount = 0;

    public GameObject PvPButton;
    public GameObject coopButton;


    public GameObject readyPlayerPanel;

    public GameObject chooseModePanel;

    [SerializeField] countDown countDownObject;



    void Start()
    {
        //hides individual player items
        P1Items.SetActive(false);
        P2Items.SetActive(false);

        //hides shared basket
        sharedBasket.SetActive(false);
    }

    public void readyPlayer(GameObject readyPlayerButton)
    {
        playerReadyCount += 1;
        Debug.Log("ready");
        readyPlayerButton.SetActive(false);

        if(playerReadyCount == 2)//if both players are ready
        {
            countDownObject.remainingTime = 30;//set timer start time to 30 seconds
            gameModeCanvas.SetActive(false);//turn off the canvas
        }


    }


    public void PvPMode()
    {
       

        
    }

    [ServerRpc(RequireOwnership = false)]
    public void hidecoopItemsServerRPC()
    {
        Debug.Log("hid coop objects");
        //turn on the individual player items
        P1Items.SetActive(true);
        P2Items.SetActive(true);


        //hide shared basket
        sharedBasket.SetActive(false);
        chooseModePanel.SetActive(false);//hide entire panel and buttons
        readyPlayerPanel.SetActive(true);//show player ready buttons
    }



    public void coopMode()
    {
        //hides individual player items
        P1Items.SetActive(false);
        P2Items.SetActive(false);

        //show shared basket
        sharedBasket.SetActive(true);

        chooseModePanel.SetActive(false);//hide entire panel and buttons
        readyPlayerPanel.SetActive(true);//show player ready buttons

        Debug.Log("cooop modeeeeeeee");
    }
}
