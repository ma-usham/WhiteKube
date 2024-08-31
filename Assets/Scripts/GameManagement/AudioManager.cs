using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXsource;
   
  
    public AudioClip background;
    public AudioClip death;
    //public AudioClip jump;
    
    public static AudioManager instance;
    private void Awake()
    {
        
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        musicSource.clip=background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }
    public void Pause()
    {
        musicSource.Pause();
        SFXsource.Pause();
    }
    public void Resume()
    {
        musicSource.UnPause();
        SFXsource.UnPause();
    }



}
