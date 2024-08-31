 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerControls playerControls;
    PlayerMovement playerMovement;
    
    public float Move;
    public bool JumpBtnClicked;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerMovement = GetComponent<PlayerMovement>();
        playerControls.Enable();
    }

    private void OnDestroy()
    {
        playerControls.Disable();
        
    }
   
    private void FixedUpdate()
    {
        InputHandler();
    }

    void InputHandler()
    {
            playerControls.onLand.Run.performed += ctx =>
            {
                Move = ctx.ReadValue<float>();
            };
            playerControls.onLand.Jump.performed += ctx =>
            {
                playerMovement.jump();
            };
    }
   
}


