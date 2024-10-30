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

    private void Start()
    {
        settingsPanel.SetActive(false);
        levelsPanel.SetActive(false);  
    }

    public void OnPlayBtnClicked()
    {
            int level = PlayerPrefs.GetInt("UnlockedLevel", 1);
            AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        if(level == 16)
        {
            levelsPanel.SetActive(true);
        }
        else
        {
            SceneController.instance.LoadScene(level + 1);
        }
            
        
        
    }
    public void OnLevelsBtnClicked()
    {
        buttonsPanel.SetActive(false);
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        levelsPanel.SetActive(true);
    }
    public void OnSettingsBtnClicked()
    {
        buttonsPanel.SetActive(false);
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        settingsPanel.SetActive(true);
    }
    public void OnBackBtnClicked()
    {
        settingsPanel.SetActive(false);
        levelsPanel.SetActive(false);
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        buttonsPanel.SetActive(true);
    }
    public void OnExitBtnClicked()
    {
        Debug.Log("Quiting");
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        Application.Quit();
    }
    public void OnRateMeBtnClicked()
    {
#if UNITY_ANDROID
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        Application.OpenURL("https://www.facebook.com/boy.mausham");
#elif UNITY_IOS
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
            Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_APP_ID");
#endif
    }


}
