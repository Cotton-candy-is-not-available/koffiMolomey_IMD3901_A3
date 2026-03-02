using UnityEngine;
using UnityEngine.UI;

public class checkMarkToggle : MonoBehaviour
{

    public Toggle fabricCheckMark;
    public Toggle trimCheckMark;
    public Toggle threadCheckMark;

    [SerializeField] basketCollision basket;

    private void Start()
    {
        fabricCheckMark.isOn = false;
        trimCheckMark.isOn = false;
        threadCheckMark.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //The state of the check marks in the UI are reliant on the state of the bools from the basketCollision script 
        //which turn on and off depending on if the object is currently colliding with the basket or not
        fabricCheckMark.isOn = basket.fabricBool;
        trimCheckMark.isOn = basket.trimBool;
        threadCheckMark.isOn = basket.threadBool;
    }
}
