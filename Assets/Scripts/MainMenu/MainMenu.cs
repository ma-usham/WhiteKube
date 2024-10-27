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
        SceneController.instance.LoadScene(level+1);
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
    public void OnExitBtnClicked()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }
    public void OnRateMeBtnClicked()
    {
#if UNITY_ANDROID
        Application.OpenURL("https://www.facebook.com/boy.mausham");
#elif UNITY_IOS
            Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_APP_ID");
#endif
    }


}
