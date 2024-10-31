using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameId;
    [SerializeField] private string iosGameId;
    [SerializeField] private bool isTesting;

    [SerializeField] private RewardedAds rewardedAds;
    [SerializeField] private InterstitialAds interstitialAds;

    private string gameId;


    private void Awake()
    {
#if UNITY_IOS
                gameId = iosGameId;
#elif UNITY_ANDROID
        gameId = androidGameId;
#elif UNITY_EDITOR
                gameId= androidGameId; // If you Havn't Switched the Platfrom...
#endif

        //Initialize();
    }

    public void Initialize()
    {
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, isTesting, this);
        }
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Ads Initialized...");
        rewardedAds.LoadRewardedAd();
        interstitialAds.LoadInterstitialAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message) {
        Debug.Log("ERROR ADS");
    }
}