using System;
using System.Collections.Generic;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Collections.Extensions;
using LittleBitGames.Environment.Ads;
using LittleBitGames.Environment.Events;

namespace LittleBitGames.Ads.MediationNetworks.MaxSdk
{
    public class MaxSdkAnalytics : IMediationNetworkAnalytics
    {
        private const string SdkSourceName = "applovin_max_sdk";
        private const string Currency = "USD";

        private readonly IReadOnlyList<IAdUnit> _adUnits;

        public event Action<IDataEventAdImpression, AdType> OnAdRevenuePaidEvent;

        public MaxSdkAnalytics(MaxSdkInitializer maxSdkInitializer, IReadOnlyList<IAdUnit> adUnits)
        {
            if (!adUnits.Validate()) ThrowException();

            _adUnits = adUnits;

            maxSdkInitializer.OnMediationInitialized += Subscribe;
        }

        private static void ThrowException() =>
            throw new Exception("Invalid list of ad units provided to MaxSdkAnalytics");

        private void Subscribe()
        {
            MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += delegate(string s, MaxSdkBase.AdInfo info)
            {
                OnAdRevenuePaid(s, info, AdType.Inter);
            };

            MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += delegate(string s, MaxSdkBase.AdInfo info)
            {
                OnAdRevenuePaid(s, info, AdType.Rewarded);
            };

            MaxSdkCallbacks.Banner.OnAdRevenuePaidEvent += delegate(string s, MaxSdkBase.AdInfo info)
            {
                OnAdRevenuePaid(s, info, AdType.Banner);
            };
        }

        private void OnAdRevenuePaid(string adUnitId, MaxSdkBase.AdInfo adInfo, AdType adType)
        {
            var ad = _adUnits.FindByKey(adUnitId);

            var adImpressionEvent = new DataEventAdImpression(
                new SdkSource("SdkSourceName"),
                adInfo.NetworkName,
                adInfo.AdFormat,
                ad.UnitPlace.StringValue,
                Currency,
                adInfo.Revenue);

            OnAdRevenuePaidEvent?.Invoke(adImpressionEvent, adType);
        }
    }
}