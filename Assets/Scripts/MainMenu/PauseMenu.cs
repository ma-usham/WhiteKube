using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    private ButtonsTransition buttonsTransition;
    
    void Start()
    {
        pausePanel.SetActive(false);
        buttonsTransition = FindObjectOfType<ButtonsTransition>();
    }

    public void OnPauseBtnClicked()
    {
        pausePanel.SetActive(true);
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        Time.timeScale = 0;
        buttonsTransition.DisableButtons();
    }
    public void OnHomeBtnClicked()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        SceneController.instance.LoadScene(1);
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void OnRestartBtnClicked()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        SceneController.instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void OnResumeBtnClicked()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        buttonsTransition.EnableButtons();
    }

}
