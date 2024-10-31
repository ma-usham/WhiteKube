using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using TMPro;

public class SkipMenu : MonoBehaviour
{
    public GameObject skipPanel;
    private ButtonsTransition buttonsTransition;
    public TextMeshProUGUI notReadyText;
    private RewardedAds rewardedAds;
 



    void Start()
    {
        notReadyText.gameObject.SetActive(false);
        skipPanel.SetActive(false);
        buttonsTransition = FindObjectOfType<ButtonsTransition>();

    }
    public void OnSkipBtnClicked()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        notReadyText.gameObject.SetActive(false);
        skipPanel.SetActive(true);
        Time.timeScale = 0;
        buttonsTransition.DisableButtons();
    }
    public void OnYestBtnClicked()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        if(Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork || Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            AudioManager.instance.Pause();
            skipPanel.SetActive(false);
            AdsManager.Instance.rewardedAds.ShowRewardedAd();
            buttonsTransition.EnableButtons();
        }
       else
       {
            StartCoroutine(RestartNotReadyText());
       }    
       
    }
    public void OnNoBtnClicked()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        skipPanel.SetActive(false);
        Time.timeScale = 1;
        buttonsTransition.EnableButtons();
    }

    private IEnumerator RestartNotReadyText()
    {
        // Temporarily disable the text
        notReadyText.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);
        notReadyText.gameObject.SetActive(true);
    }

}
