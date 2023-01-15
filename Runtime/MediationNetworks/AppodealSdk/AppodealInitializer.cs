using System;
using System.Collections.Generic;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using LittleBitGames.Ads.Configs;
using LittleBitGames.Environment.Ads;
using UnityEngine;

namespace LittleBitGames.Ads.MediationNetworks.AppodealSdk
{
    public class AppodealInitializer : IMediationNetworkInitializer, IAppodealInitializationListener
    {
        public event Action OnMediationInitialized;
        private readonly AdsConfig _config;
        private int _adTypes;
        public AppodealInitializer(AdsConfig config) => _config = config;
        private bool IsDebugMode => _config.Mode is ExecutionMode.Debug;
        
        public void Initialize()
        {
            if (_config.IsInter && _config.IsRewarded)
            {
                _adTypes = AppodealAdType.Interstitial | AppodealAdType.RewardedVideo;
            }
            else if (_config.IsInter)
            {
                _adTypes = AppodealAdType.Interstitial;
            }
            else if (_config.IsRewarded)
            {
                _adTypes = AppodealAdType.RewardedVideo;
            }
                
            
            #if UNITY_ANDROID
            Appodeal.Initialize(_config.AppodealSettings.AppIdAndroid, _adTypes);
            #elif UNITY_IOS
            Appodeal.Initialize(_config.AppodealSettings.AppIdIos, _adTypes);
            #endif
        }

        public void OnInitializationFinished(List<string> errors)
        {
            OnMediationInitialized?.Invoke();
            if (IsDebugMode) Debug.Log("DebugMode");
        }
    }
}