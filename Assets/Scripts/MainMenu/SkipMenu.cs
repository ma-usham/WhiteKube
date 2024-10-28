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
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        skipPanel.SetActive(true);
        Time.timeScale = 0;
        buttonsTransition.DisableButtons();
    }
    public void OnYestBtnClicked()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        skipPanel.SetActive(false);
        buttonsTransition.EnableButtons();
        AudioManager.instance.Pause();
        Time.timeScale = 1;
        AdsManager.Instance.rewardedAds.ShowRewardedAd();
    }
    public void OnNoBtnClicked()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        skipPanel.SetActive(false);
        Time.timeScale = 1;
        buttonsTransition.EnableButtons();
    }

}
