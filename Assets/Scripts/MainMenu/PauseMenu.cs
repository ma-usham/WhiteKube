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
        buttonsTransition.DisableButtons();
    }
    public void OnHomeBtnClicked()
    {
        SceneController.instance.LoadScene(0);
        pausePanel.SetActive(false);
    }
    public void OnRestartBtnClicked()
    {
        SceneController.instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pausePanel.SetActive(false);
    }
    public void OnResumeBtnClicked()
    {
        pausePanel.SetActive(false);
        buttonsTransition.EnableButtons();
    }

}
