using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsTransition : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    PlayerInput playerInput;

    private void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    public void DisableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
            playerInput.Move = 0;
            playerInput.playerControls.Disable();
            Debug.Log("BUTTONS DISABLED");
        }
    }
    public void EnableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
            playerInput.playerControls.Enable();
        }
    }
}
