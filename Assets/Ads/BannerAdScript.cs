using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class BannerAdScript : MonoBehaviour
{
    private string _adUnitId = "ca-app-pub-3253759534064842/3110607122";

    BannerView _bannerView;


    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            CreateBannerView();
            LoadAd();
        });
    }


    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyAd();
        }

        // Create a 320x50 banner at top of the screen
        _bannerView = new BannerView(_adUnitId, AdSize.Leaderboard, AdPosition.Bottom);
        
    }

    public void LoadAd()
    {
        // create an instance of a banner view first.
        if (_bannerView == null)
        {
            CreateBannerView();
        }
        // create our request used to load the ad.
        var adRequest = new AdRequest.Builder()
            .AddKeyword("unity-admob-sample")
            .Build();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }

    public void DestroyAd()
    {
        if (_bannerView != null)
        {
            Debug.Log("Destroying banner ad.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}