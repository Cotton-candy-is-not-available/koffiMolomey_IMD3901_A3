using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public CharacterController charController;
    public Transform camTransform;
    private float xRotation = 0.0f;

    public Camera PcCamera;

    [SerializeField] Transform p1StartPos;
    [SerializeField] Transform p2StartPos;

    gameManager numOfPlayers;

    bool isLocked = true;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            PcCamera.enabled = false;
        }

        //Print player ids
        Debug.Log("Client  id: "+ NetworkManager.Singleton.LocalClientId);

        //Spawn players at their start position 
        if (NetworkManager.Singleton.LocalClientId == 0)
        {
            Debug.Log("Player 1");
            gameObject.transform.transform.position = p1StartPos.position;//player 1 start position
            //Add to number of total players
            numOfPlayers =  GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>();//access game manager component
            numOfPlayers.playerCounter +=1;//increase counter by 1
            Debug.Log("numOfPlayers: "+ numOfPlayers.playerCounter);

            PcCamera.tag = "P1Camera";//set player camera tag

        }
        else if (NetworkManager.Singleton.LocalClientId == 1)
        {
            Debug.Log("Player 2");
            //Add to number of total players
            numOfPlayers =  GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>();//access game manager component
            numOfPlayers.playerCounter +=1;//increase counter by 1
            Debug.Log("numOfPlayers: "+ numOfPlayers.playerCounter);

            PcCamera.tag = "P2Camera";//set player camera tag

        }

        Cursor.lockState = CursorLockMode.Locked; //locks the cursor to the screen, so it moves with the camera
        Cursor.visible = false;//hides cursor 

        //NetworkManager.GetNetworkPrefabOverride(VRTextureUsage/pcPrefabs);//to chnage prefabs

    }



    void Update()
    {
        //Networking
        if (!IsOwner)
        {
            return;
        }

        //-1 in the negative direction along x or y, +1 in the positive direction
        Vector2 moveInput = Keyboard.current != null ? new Vector2
            (
                (Keyboard.current.aKey.isPressed ? -1 : 0) + (Keyboard.current.dKey.isPressed ? 1 : 0),
                (Keyboard.current.sKey.isPressed ? -1 : 0) + (Keyboard.current.wKey.isPressed ? 1 : 0)
            ) : Vector2.zero;

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        charController.Move(move * speed * Time.deltaTime); //apply the movement to the player

        Vector2 mouseDelta = Mouse.current.delta.ReadValue(); //read the values from the mouse
        float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

        //when we move our mouse up or down, we want the player to look up, not for the camera to flip
        //create a restriction and clamp the value
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30f, 80f);

        //euler inputs a number in degrees
        camTransform.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX); //apply it to the camera

        //unlock and lock cursor when i is pressed
        if (Keyboard.current.iKey.wasPressedThisFrame)//press e to grab and drop object
        {
            if (isLocked)
            {
                isLocked = !isLocked;
                Cursor.lockState = CursorLockMode.None; //locks the cursor to the screen, so it moves with the camera
                Cursor.visible = true;//hides cursor 
            }
            else
            {
                isLocked = !isLocked;
                Cursor.lockState = CursorLockMode.Locked; //locks the cursor to the screen, so it moves with the camera
                Cursor.visible = false;//hides cursor 
            }
        }





        }
}
