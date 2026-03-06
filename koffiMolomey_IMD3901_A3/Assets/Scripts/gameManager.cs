using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class gameManager : MonoBehaviour
{
    [Header("----------- Baskets ------------")]
    [SerializeField] GameObject P1Basket;
    [SerializeField] GameObject P2Basket;

    [SerializeField] GameObject sharedBasket;

    basketCollision P1BasketCollison;
    basketCollision P2BasketCollison;

    basketCollision sharedBasketCollison;

    [Header("----------- dressForm ------------")]
    [SerializeField] GameObject dressForm;


    [SerializeField] countDown countDownObject;

    [Header("----------- Winner Text ------------")]
    public GameObject winnerText;

    buttonFunctions buttonFunctions;


    public bool timeIsOver = false;

    [Header("----------- Lists of fabric materials ------------")]
    public GameObject[] fabricGroups;
    String chosenFabric;
    String chosenTrim;
    String chosenThread;

    //bools to check which playyer won
    bool P1Win = false;
    bool P2Win = false;

    bool coopWin = false;

    public buttonFunctions playerReady;
    public int playerCounter = 0;


    private void Start()
    {
        winnerText.SetActive(false);//be off on start
        //Get basket collsion script to acces variables of specific player
        P1BasketCollison = P1Basket.GetComponent<basketCollision>();
        P2BasketCollison = P2Basket.GetComponent<basketCollision>();

        //for (int i = 0; i < fabricGroups.Length; i++)
        //{

        //}

        int randomFabricItem = Random.Range(0, fabricGroups.Length);//chose any frabric group from the fabric group array

        //Chose material to add to refernece dressForm
        chosenFabric = fabricGroups[randomFabricItem].GetComponent<createDressClass>().fabricMat.name;
        Debug.Log(" chosenFabric:" + chosenFabric);
        chosenTrim = fabricGroups[randomFabricItem].GetComponent<createDressClass>().trimObject.name;
        Debug.Log(" chosenTrim:" + chosenTrim);

        chosenThread = fabricGroups[randomFabricItem].GetComponent<createDressClass>().threadObject.name;
        Debug.Log(" chosenThread:" + chosenThread);

        //Assign material from chosen fabric group to mannequin
        dressForm.GetComponent<MeshRenderer>().material = fabricGroups[randomFabricItem].GetComponent<createDressClass>().fabricMat;

    }


    private void Update()
    {
        //if the time is over and both players pressed the player ready button
        //if (timeIsOver && playerReady.playerReadyCount == 2)//when the timer reaches zero and timeIsOver is set to true 

        if (timeIsOver )//when the timer reaches zero and timeIsOver is set to true 
            {
            Debug.Log("check winner");
            //checkItemsInBaskets(P1BasketCollison.fabricBool, P1BasketCollison.trimBool, P1BasketCollison.fabricBool);
            checkItemsInBaskets();//check which items are in the basket

            checkWinner();//check the winner

        }
        //else if (!timeIsOver && playerCounter == 1&& buttonFunctions.playerReadyCount == 2)//let the countdown timer start as long as there are atleats 2 players in the game
        else if (!timeIsOver && playerCounter == 2 )//let the countdown timer start as long as there are atleats 2 players in the game and both are ready
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
            if (P2BasketCollison.fabricName == chosenFabric+"Fabric" && P2BasketCollison.trimName == chosenTrim)//add thread check too
            {
                Debug.Log("Player 2 wins!!!");
                P2Win = true;
                
            }
        }
        else
        {
            Debug.Log("P2 Need more items");
        }


        //check the shared basket
        if (sharedBasketCollison.fabricBool && sharedBasketCollison.trimBool && sharedBasketCollison.threadBool)//the players have all the items in their basket
        {
            Debug.Log("Co-Op Got all three items");
            //check if all the items in the basket match with the ones chosen at the start of the game
            if (P1BasketCollison.fabricName == chosenFabric+"Fabric" && P1BasketCollison.trimName == chosenTrim)//add thread check too
            {
                Debug.Log("You both won!!!");
                coopWin = true;
               

            }
        }
        else
        {
            Debug.Log("Co-Op Need more items");
        }




    }



    private void checkWinner()
    {
        if (P1Win)//if both player 1 and 2 win
        {
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 1 wins";//change text to say player 1 won
            winnerText.SetActive(true);//turn on to show who won

        }

        if (P2Win)//if both player 1 and 2 win
        {
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 2 wins";//change text to say player 2 won
            winnerText.SetActive(true);//turn on to show who won
        }

        if (P1Win && P2Win)//if both player 1 and 2 win
        {
            Debug.Log("Its a tie!!");
            winnerText.GetComponent<TextMeshProUGUI>().text = "It's a tie!";//dispaly its a tie text
            winnerText.SetActive(true);//turn on to show who won


        }
        else if (!P1Win && !P2Win)//if neither player wins
        {
            Debug.Log("No winner");
            winnerText.GetComponent<TextMeshProUGUI>().text = "No one won :(";
            winnerText.SetActive(true);//turn on to show who won

        }

        //For co-op play
        if (coopWin)
        {
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "You guys won!";//change text to say player 1 won
            winnerText.SetActive(true);//turn on to show who won
        }
        else if (!coopWin)
        {
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "You guys lost :(";//change text to say player 1 won
            winnerText.SetActive(true);//turn on to show who won
        }


    }






}
