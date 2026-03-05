using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [Header("----------- Baskets ------------")]
    [SerializeField] GameObject P1Basket;
    [SerializeField] GameObject P2Basket;

    basketCollision P1BasketCollison;
    basketCollision P2BasketCollison;

    [Header("----------- Mannequin ------------")]
    [SerializeField] GameObject mannequin;


    [SerializeField] countDown countDownObject;

    [Header("----------- Winner Text ------------")]
    public GameObject winnerText;



    public bool timeIsOver = false;

    [Header("----------- Lists of fabric materials ------------")]
    public GameObject[] fabricGroups;
    String chosenFabric;
    String chosenTrim;
    String chosenThread;

    //bools to check which playyer won
    bool P1Win = false;
    bool P2win = false;

    public buttonFunctions playerReady;
    public int playerCounter = 0;


    private void Start()
    {
        winnerText.SetActive(false);//be off on start
        //Get basket collsion script to acces variables of specific player
        P1BasketCollison = P1Basket.GetComponent<basketCollision>();
        P2BasketCollison = P2Basket.GetComponent<basketCollision>();


        //Assign material from chosen fabric group to mannequin
        mannequin.GetComponent<MeshRenderer>().material = fabricGroups[0].GetComponent<createDressClass>().fabricMat;

        //Chose material to add to refernece manequin
        chosenFabric = fabricGroups[0].GetComponent<createDressClass>().fabricMat.name;
        Debug.Log(" chosenFabric:" + chosenFabric);
        chosenTrim = fabricGroups[0].GetComponent<createDressClass>().trimObject.name;
        Debug.Log(" chosenTrim:" + chosenTrim);

        chosenThread = fabricGroups[0].GetComponent<createDressClass>().threadObject.name;
        Debug.Log(" chosenThread:" + chosenThread);

        //set time to 0 on 
        //countDownObject.remainingTime = 0;

    }


    private void Update()
    {
        //if the time is over and bioth players pressed the player ready button
        if (timeIsOver && playerReady.playerReadyCount == 2)//when the timer reaches zero and timeIsOver is set to true 
        {
            Debug.Log("check winner");
            //checkItemsInBaskets(P1BasketCollison.fabricBool, P1BasketCollison.trimBool, P1BasketCollison.fabricBool);
            checkItemsInBaskets();//check which items are in the basket

            checkWinner();//check the winner

        }//check in GraphicRaycasterUI if playerReadyCount ==2, playerCounter == 2
        else if (!timeIsOver && playerCounter == 1 && playerReady.playerReadyCount ==2)//let the countdown timer start as long as there are atleats 2 players in the game
        {
            Debug.Log("counter going down");
            countDownObject.startCountDown();//start the count down and keep it running as long as timeIsOver is false
        }


    }


    //private void checkItemsInBaskets(bool fabric, bool trim, bool thread)
    private void checkItemsInBaskets()
    {
        //cjheck player 1's basket
        if (P1BasketCollison.fabricBool && P1BasketCollison.trimBool && P1BasketCollison.threadBool)//the player has all the items in their basket
        {
            Debug.Log("Got all three items");
            //check if the fabrics in thew basket match with the ones chosen at the start of the game
            if (P1BasketCollison.fabricName == chosenFabric+"Fabric" && P1BasketCollison.trimName == "tempRibbon")
            {
                Debug.Log("Player 1 wins!!!");
                P1Win = true;
                winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 1 wins";//change text to say player 1 won
                winnerText.SetActive(true);//turn on to show who won

            }
        }
        else
        {
            Debug.Log("P1 Need more items");
        }


        //check player 2's basket
        if (P2BasketCollison.fabricBool && P2BasketCollison.trimBool && P2BasketCollison.threadBool)//the player has all the items in their basket
        {
            Debug.Log("Got all three items");
            //check if all the items in the basket match with the ones chosen at the start of the game
            if (P1BasketCollison.fabricName == chosenFabric+"Fabric" && P1BasketCollison.trimName == chosenTrim)//add thread check too
            {
                Debug.Log("Player 1 wins!!!");
                P1Win = true;
                winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 1 wins";//change text to say player 1 won
                winnerText.SetActive(true);//turn on to show who won

            }
        }
        else
        {
            Debug.Log("P2 Need more items");
        }
    }



    private void checkWinner()
    {
        if (P1Win && P2win)//if both player 1 and 2 win
        {

            Debug.Log("Its a tie!!");
            winnerText.GetComponent<TextMeshProUGUI>().text = "It's a tie!";//dispaly its a tie text
            winnerText.SetActive(true);//turn on to show who won


        }
        else if (!P1Win && !P2win)//if neither player wins
        {
            Debug.Log("No winner");
            winnerText.GetComponent<TextMeshProUGUI>().text = "No one won :(";
            winnerText.SetActive(true);//turn on to show who won

        }
    }






}
