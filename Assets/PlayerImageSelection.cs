using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerImageSelection : MonoBehaviour
{
    public Button[] buttons; // Array of buttons representing player images

    private const string SelectedPlayerKey = "Player";

    private void Awake()
    {


        int unlockedImages = PlayerPrefs.GetInt("UnlockedPlayer", 1);

        // Initialize buttons and "Selected" text
        for (int i = 0; i < buttons.Length; i++)
        {
            // Disable button interactability by default
            buttons[i].interactable = false;

            // Show "Locked" or "Selected" text by accessing the second child (index 1)
            TextMeshProUGUI btnTxt = buttons[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            if (btnTxt != null)
            {
                btnTxt.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError($"TextMeshProUGUI component not found on Button {i}'s child.");
            }
        }

        // Enable buttons based on unlocked images
        for (int i = 0; i < unlockedImages; i++)
        {
            buttons[i].interactable = true;

            TextMeshProUGUI btnTxt = buttons[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            if (btnTxt != null)
            {
                btnTxt.text = ""; // Clear text for unlocked images
                btnTxt.gameObject.SetActive(false); // Hide initially
            }
        }

        // Display "Selected" text for the previously chosen player
        int selectedPlayerIndex = PlayerPrefs.GetInt(SelectedPlayerKey, 0);
        if (selectedPlayerIndex >= 0 && selectedPlayerIndex < buttons.Length)
        {
            ShowSelectedText(selectedPlayerIndex);
        }
    }

    public void SelectPlayer(int playerIndex)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        // Save the selected player index in PlayerPrefs
        PlayerPrefs.SetInt(SelectedPlayerKey, playerIndex);
        PlayerPrefs.Save();

        // Update the UI to show "Selected" text
        ShowSelectedText(playerIndex);
    }

    private void ShowSelectedText(int playerIndex)
    {
        
        // Clear "Selected" text from all buttons
        foreach (Button btn in buttons)
        {
            TextMeshProUGUI btnTxt = btn.transform.Find("selectedText").GetComponent<TextMeshProUGUI>();
            if (btnTxt != null)
            {
                btnTxt.gameObject.SetActive(false); // Hide all labels initially
            }
        }

        // Display "Selected" text for the chosen player
        TextMeshProUGUI selectedText = buttons[playerIndex].transform.Find("selectedText").GetComponent<TextMeshProUGUI>();
        if (selectedText != null)
        {
            //selectedText.text = "Selected";
            selectedText.gameObject.SetActive(true);
        }
    }
}
