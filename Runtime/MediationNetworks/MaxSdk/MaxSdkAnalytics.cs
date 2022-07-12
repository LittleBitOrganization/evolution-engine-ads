using System;
using System.Collections.Generic;
using Events;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Collections.Extensions;

namespace LittleBitGames.Ads.MediationNetworks.MaxSdk
{
    public class MaxSdkAnalytics : IMediationNetworkAnalytics
    {
        private const string SdkSourceName = "AppLovinMax";
        private const string Currency = "USD";

        private readonly List<IAdUnit> _adUnits;

        public event Action<IDataEventAdImpression, AdType> OnAdRevenuePaidEvent;

        public MaxSdkAnalytics(MaxSdkInitializer maxSdkInitializer, List<IAdUnit> adUnits)
        {
            if (!adUnits.Validate()) ThrowException();

            _adUnits = adUnits;

            maxSdkInitializer.OnMediationInitialized += Subscribe;
        }

        private static void ThrowException() =>
            throw new Exception("Invalid list of ad units provided to MaxSdkAnalytics");

        private void Subscribe()
        {
            MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += delegate(string s, MaxSdkBase.AdInfo info) { OnAdRevenuePaid(s, info, AdType.Inter); };
            
            MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += delegate(string s, MaxSdkBase.AdInfo info) { OnAdRevenuePaid(s, info, AdType.Rewarded); };
        }

        private void OnAdRevenuePaid(string adUnitId, MaxSdkBase.AdInfo adInfo, AdType adType)
        {
            var ad = _adUnits.FindByKey(adUnitId);

            var adImpressionEvent = new DataEventAdImpression(
                new SdkSource(SdkSourceName),
                adInfo.NetworkName,
                adInfo.AdFormat,
                ad.UnitPlace.StringValue,
                Currency,
                adInfo.Revenue);

            OnAdRevenuePaidEvent?.Invoke(adImpressionEvent, adType);
        }
    }
}