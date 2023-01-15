using System;

namespace LittleBitGames.Ads.AdUnits
{
    public class MaxSdkInterEvents : IAdUnitEvents
    {
        public event Action<string, AdInfo> OnAdRevenuePaid;
        public event Action<string, AdInfo> OnAdLoaded;
        public event Action<string, AdErrorInfo> OnAdLoadFailed;
        public event Action<string, AdInfo> OnAdFinished;
        public event Action<string, AdInfo> OnAdClicked;
        public event Action<string, AdInfo> OnAdHidden;
        public event Action<string, AdErrorInfo, AdInfo> OnAdDisplayFailed;

        public MaxSdkInterEvents()
        {

            MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += (s, info) => OnAdLoaded?.Invoke(s, new AdInfo(info));
            MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += (s, info) => OnAdLoadFailed?.Invoke(s, new AdErrorInfo(info));
            MaxSdkCallbacks.Interstitial.OnAdClickedEvent += (s, info) => OnAdClicked?.Invoke(s, new AdInfo(info));
            MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += (s, info) => OnAdHidden?.Invoke(s, new AdInfo(info));
            MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent +=
                (s, error, info) => OnAdDisplayFailed?.Invoke(s, new AdErrorInfo(error), new AdInfo(info));
            
            MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += (s, info) =>
            {
                #if UNITY_EDITOR
                OnAdFinished?.Invoke(s, new AdInfo(info));
                #endif
            };
            
            MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += (s, info) =>
            {
                OnAdRevenuePaid?.Invoke(s, new AdInfo(info));
                OnAdFinished?.Invoke(s, new AdInfo(info));
            };
        }
        
    }
}