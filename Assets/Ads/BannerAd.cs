using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAd : MonoBehaviour
{
    private BannerView bannerView;



    void Start()
    {
        RequestBanner();
    }







    private void RequestBanner()
    {

        string adUnitId = "ca-app-pub-3253759534064842/3110607122";


        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Leaderboard, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
}