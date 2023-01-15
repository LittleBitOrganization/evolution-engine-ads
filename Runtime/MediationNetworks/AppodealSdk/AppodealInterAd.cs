using System;
using AppodealStack.Monetization.Common;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;

namespace LittleBitGames.Ads.MediationNetworks.AppodealSdk
{
    public class AppodealInterAd: AppodealAdUnit
    {
        private readonly IAdUnitKey _key;

        public AppodealInterAd(IAdUnitKey key, ICoroutineRunner coroutineRunner) : base(key,
            new AppodealInterEvents(), coroutineRunner) => _key = key;

        protected override bool IsAdReady() => global::MaxSdk.IsInterstitialReady(_key.StringValue);

        protected override void ShowAd() => global::MaxSdk.ShowInterstitial(_key.StringValue);
        public override void Load() => global::MaxSdk.LoadInterstitial(_key.StringValue);
        public override void OnAdLoadFailed(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
        {
            throw new NotImplementedException();
        }

        public override void OnAdHiddenEvent(string adUnitId, AppodealAdRevenue adInfo)
        {
            throw new NotImplementedException();
        }
    }
}