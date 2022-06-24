using System;

namespace LittleBitGames.Ads.AdUnits
{
    public class MaxSdkInterEvents : IAdUnitEvents
    {
        public event Action<string, MaxSdkBase.AdInfo> OnAdRevenuePaid;
        public event Action<string, MaxSdkBase.AdInfo> OnAdLoaded;
        public event Action<string, MaxSdkBase.ErrorInfo> OnAdLoadFailed;
        public event Action<string, MaxSdkBase.AdInfo> OnAdDisplayed;
        public event Action<string, MaxSdkBase.AdInfo> OnAdClicked;
        public event Action<string, MaxSdkBase.AdInfo> OnAdHidden;
        public event Action<string, MaxSdkBase.ErrorInfo, MaxSdkBase.AdInfo> OnAdDisplayFailed;

        public MaxSdkInterEvents()
        {
            MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += (s, info) => OnAdRevenuePaid?.Invoke(s, info);
            MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += (s, info) => OnAdLoaded?.Invoke(s, info);
            MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += (s, info) => OnAdLoadFailed?.Invoke(s, info);
            MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += (s, info) => OnAdDisplayed?.Invoke(s, info);
            MaxSdkCallbacks.Interstitial.OnAdClickedEvent += (s, info) => OnAdClicked?.Invoke(s, info);
            MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += (s, info) => OnAdHidden?.Invoke(s, info);
            MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += (s, error, info) => OnAdDisplayFailed?.Invoke(s, error, info);
        }
    }
}