using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.InputSystem;

public class AdsManager : MonoBehaviour
{
    public InitializeAds initializeAds;
   // public BannerAds bannerAds;
   // public InterstitialAds interstitialAds;
    public RewardedAds rewardedAds;
    public InterstitialAds interstitialAds;

    public static AdsManager Instance { get; private set; }



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            initializeAds.Initialize();   
        }
    
    }
}