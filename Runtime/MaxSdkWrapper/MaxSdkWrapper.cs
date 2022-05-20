using System;
using LittleBit.Modules.EnvironmentCoreModule;
using UnityEngine;

namespace LittleBit.Modules.Ads
{
    public partial class MaxSdkWrapper : MonoBehaviour, IMediationNetwork
    {
        private ApplovinSettings _applovinSettings;
        private IAdUnit _rewardedAdUnit;

        private string _sdkKey;

        public event Action<IDataEventAdImpression> OnAdRevenuePaidEvent;
        
        /// <summary>
        /// Need be initialized before Start
        /// </summary>
        /// <param name="rewardedAdUnit"></param>
        public void Init(RewardedAdUnit rewardedAdUnit, ApplovinSettings applovinSettings)
        {
            _applovinSettings = applovinSettings;
            _rewardedAdUnit = rewardedAdUnit;
            _sdkKey = _applovinSettings.SDKKey;
        }

        private void Start()
        {
            MaxSdkCallbacks.OnSdkInitializedEvent += sdkConfiguration =>
            {
                InitializeAds(_applovinSettings);
                OnInitialized?.Invoke();
                MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnAdRevenuePaid;

                //MaxSdk.ShowMediationDebugger();
            };

            MaxSdk.SetSdkKey(_sdkKey);
            MaxSdk.SetUserId("USER_ID");

            MaxSdk.InitializeSdk();
        }

        private void OnAdRevenuePaid(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            var adImpressionEvent = new DataEventAdImpression(
                adInfo.NetworkName,
                adInfo.AdFormat,
                adInfo.AdUnitIdentifier,
                "USD",
                adInfo.Revenue);

            OnAdRevenuePaidEvent?.Invoke(adImpressionEvent);
        }

        private void InitializeAds(ApplovinSettings applovinSettings)
        {
            _rewardedAdUnit.Initialize(applovinSettings);
        }

        public void ShowRewardedAd(Action<bool> callback)
        {
            _rewardedAdUnit.OnFinish += callback;
            _rewardedAdUnit.Show();
        }

        public event Action OnInitialized;
    }
}