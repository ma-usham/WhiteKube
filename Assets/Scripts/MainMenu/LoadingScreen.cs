using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingPanel;

    void Start()
    {
        loadingPanel.SetActive(true);
        StartCoroutine(LoadAsyncScene());
        PlayerPrefs.DeleteAll();

        // Ensure the changes are saved immediately
        PlayerPrefs.Save();
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        loadingPanel.SetActive(false);
    }
}
