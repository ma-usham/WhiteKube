using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public Animator transitionAnim;
    public Image transitionImage;
    private void Awake()
    {

        transitionImage.gameObject.SetActive(false);
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
        transitionImage.gameObject.SetActive(true);
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        if (SceneManager.GetActiveScene().buildIndex % 3 == 0 && (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork || Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork))
        {
            AudioManager.instance.Pause();
            AdsManager.Instance.interstitialAds.ShowInterstitialAd();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        transitionImage.gameObject.SetActive(false);
    }
    IEnumerator RestartLevel()
    {
       transitionImage.gameObject.SetActive(true);
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        transitionImage.gameObject.SetActive(false);
    }
    IEnumerator loadWithIndex(int sceneIndex)
    {
        transitionImage.gameObject.SetActive(true);
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
        transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        transitionImage.gameObject.SetActive(false);
    }
}
