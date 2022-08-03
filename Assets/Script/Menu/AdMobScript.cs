using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;
using Random = UnityEngine.Random;

public class AdMobScript : MonoBehaviour
{

    string App_ID = "ca-app-pub-2667430731300593~1851964761";

    string IntAdsID = "ca-app-pub-2667430731300593/4833351325";
    string AdsForGame = "ca-app-pub-2667430731300593/7651086355";

    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;
    private int play;
    void Start()
    {
        //MobileAds.Initialize(App_ID);
        MobileAds.Initialize(initStatus => {});
        play = Random.Range(0, 4);

        this.RequestInt();
        this.RequestRewardBasedVideo();
    }

    public void RequestInt()
    {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-2667430731300593/4833351325";
#else
        string adUnitId = "unexpected_platform";
        #endif
        this.interstitial = new InterstitialAd(IntAdsID);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        
        if(this.interstitial.IsLoaded())
        {
            if(play == 2)
            {
                this.interstitial.Show();
            }
        }
    }

    public void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-2667430731300593/7651086355";
#else
        string adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(AdsForGame);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);


    }
    public void ShowRewardBasedVideo()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    //REWARDED ADS
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("Rewarded Ads loaded");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("Failed to load Ads");
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("Rewarded Ads Opening");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print("Failed to show Ads");
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        Wallet.SetAmount(Wallet.GetAmount() + 2);
        Achievement.SetRuby(Achievement.GetRuby() + 2f);
        MonoBehaviour.print("Add two diamons");
    }

    //INT AD TO CONTROL SHEET
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("Failed to load Ads");
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
}
