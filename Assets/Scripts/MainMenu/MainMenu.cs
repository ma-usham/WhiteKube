using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject levelsPanel;
    public GameObject buttonsPanel;

    
    public void OnPlayBtnClicked()
    {
        int level = PlayerPrefs.GetInt("UnlockedLevel", 1);
        SceneController.instance.LoadScene(level);
    }
    public void OnLevelsBtnClicked()
    {
        buttonsPanel.SetActive(false);
        levelsPanel.SetActive(true);
    }
    public void OnSettingsBtnClicked()
    {
        buttonsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void OnBackBtnClicked()
    {
        settingsPanel.SetActive(false);
        levelsPanel.SetActive(false);
        buttonsPanel.SetActive(true);
    }


}
