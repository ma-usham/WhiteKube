using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class SkipMenu : MonoBehaviour
{
    public GameObject skipPanel;
    private ButtonsTransition buttonsTransition;
   
    

    void Start()
    {
        skipPanel.SetActive(false);
        buttonsTransition = FindObjectOfType<ButtonsTransition>();
        
    }
    public void OnSkipBtnClicked()
    {
        skipPanel.SetActive(true);
        Time.timeScale = 0;
        buttonsTransition.DisableButtons();
    }
    public void OnYestBtnClicked()
    {
        skipPanel.SetActive(false);
        buttonsTransition.EnableButtons();
        AudioManager.instance.Pause();
        Time.timeScale = 1;
        AdsManager.Instance.rewardedAds.ShowRewardedAd();
    }
    public void OnNoBtnClicked()
    {
       skipPanel.SetActive(false);
        Time.timeScale = 1;
        buttonsTransition.EnableButtons();
    }

}
