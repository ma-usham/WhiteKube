using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
   // public Animator transitionAnim;

   // Canvas canvas;
   // Image image;
    private void Awake()
    {
       // canvas = GetComponentInChildren<Canvas>();
       // image = canvas.GetComponentInChildren<Image>();
       // image.gameObject.SetActive(false);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }

    }
    public void LoadScene( int sceneIndex)
    {
        StartCoroutine(loadWithIndex(sceneIndex));

    }
    public void Restart()
    {

        StartCoroutine(RestartLevel());
        
    }
    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
       // image.gameObject.SetActive(true);
        //transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        //image.gameObject.SetActive(false);
    }
    IEnumerator RestartLevel()
    {
       // image.gameObject.SetActive(true);
        //transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        //image.gameObject.SetActive(false);
    }
    IEnumerator loadWithIndex(int sceneIndex)
    {
        //image.gameObject.SetActive(true);
        //transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
        //transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
       // image.gameObject.SetActive(false);
    }
}
