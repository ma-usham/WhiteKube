using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
           
            buttons[i].interactable = false;


            TextMeshProUGUI btnTxt = buttons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

            if (btnTxt != null)
            {
                
                Color textColor = btnTxt.color;
                textColor.a = 0.5f;
                btnTxt.color = textColor;
            }
            else
            {
                Debug.LogError($"TextMeshProUGUI component not found on Button {i}'s child.");
            }
        }

       
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;

            TextMeshProUGUI btnTxt = buttons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

            if (btnTxt != null)
            {
                // Set the text opacity to 100% (alpha = 1.0f)
                Color textColor = btnTxt.color;
                textColor.a = 1.0f;
                btnTxt.color = textColor;
            }
        }
    }

    public void OpenLevel(int levelId)
    {
        SceneController.instance.LoadScene(levelId);
    }
}
