using TMPro;
using Unity.Netcode;
using UnityEngine;

public class countDown : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI countDownText;
    [SerializeField] float remainingTime = 30;//start timer with 30 seconds

    // Update is called once per frame
    public void startCountDown(bool timeIsOver)
    {
        if (remainingTime > 0)//if the remaining time is not at 0 yet, keep counting down
        {
            remainingTime -= Time.deltaTime;
        }
        else//when it reaches 0, set it to 0 so it won't be negative
        {
            remainingTime = 0;
            timeIsOver = true;
            countDownText.color = Color.red;//set text to red
        }
        //formats remaining time into minutes an seconds so that the numbers are comprehensable to players and not changing every frame
        int minutes = Mathf.FloorToInt(remainingTime / 60);//divide remaining time into minutes
        int seconds = Mathf.FloorToInt(remainingTime % 60);//divide remaining time into seconds

        countDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);//format remaining time to string so it can be set to UI text for players to see
    }
}
