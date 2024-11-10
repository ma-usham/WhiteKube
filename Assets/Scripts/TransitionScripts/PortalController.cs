using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalController : MonoBehaviour
{
    Animation Anim;
    GameObject Player;
    Rigidbody2D playerRB;

    ButtonsTransition buttonTransition;
    PlayerInput playerInput;
 

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Anim = Player.GetComponent<Animation>();
        buttonTransition = FindObjectOfType<ButtonsTransition>();
        playerInput = FindObjectOfType<PlayerInput>();
        playerRB = Player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
         
            UnlockNewLevel();
            StartCoroutine(PortalIn());
        }
    }


    IEnumerator PortalIn()
    {
        playerRB.simulated = false;
        playerInput.Move = 0;
        playerInput.playerControls.Disable();
        buttonTransition.DisableButtons();
        Anim.Play("PlayerInPortal");
        StartCoroutine(MoveInsidePortal());
        yield return new WaitForSeconds(0.5f);
        if (SceneManager.GetActiveScene().buildIndex == 16) { SceneController.instance.LoadScene(1); } // last level
        else SceneController.instance.NextLevel();
    }
    IEnumerator MoveInsidePortal()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.portalInSound);
        float timer = 0;
        while(timer < 0.5f)
        {
            Player.transform.position = Vector2.MoveTowards(Player.transform.position, transform.position, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        timer += Time.deltaTime;
    }
    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel",1)+1);
            PlayerPrefs.Save();

            if ( SceneManager.GetActiveScene().buildIndex>4 &&SceneManager.GetActiveScene().buildIndex % 2 == 1)
            {
                PlayerPrefs.SetInt("UnlockedPlayer", PlayerPrefs.GetInt("UnlockedPlayer", 1) + 1);
                Debug.Log("PLayerUnloced");
                PlayerPrefs.Save();
            }


        }

    }

}
