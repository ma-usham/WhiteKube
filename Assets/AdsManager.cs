using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour
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
        Debug.Log("ADS LOADED");
        Time.timeScale = 1;
        //next level
    }
    public void OnNoBtnClicked()
    {
       skipPanel.SetActive(false);
        Time.timeScale = 1;
        buttonsTransition.EnableButtons();
    }

}
