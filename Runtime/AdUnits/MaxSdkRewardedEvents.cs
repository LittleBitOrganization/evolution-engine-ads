using System;

namespace LittleBitGames.Ads.AdUnits
{
    public class MaxSdkRewardedEvents : IAdUnitEvents
    {
        public event Action<string, MaxSdkBase.AdInfo> OnAdRevenuePaid;
        public event Action<string, MaxSdkBase.AdInfo> OnAdLoaded;
        public event Action<string, MaxSdkBase.ErrorInfo> OnAdLoadFailed;
        public event Action<string, MaxSdkBase.AdInfo> OnAdDisplayed;
        public event Action<string, MaxSdkBase.AdInfo> OnAdClicked;
        public event Action<string, MaxSdkBase.AdInfo> OnAdHidden;
        public event Action<string, MaxSdkBase.ErrorInfo, MaxSdkBase.AdInfo> OnAdDisplayFailed;

        public MaxSdkRewardedEvents()
        {
            MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += (s, info) => OnAdRevenuePaid?.Invoke(s, info);
            MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += (s, info) => OnAdLoaded?.Invoke(s, info);
            MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += (s, info) => OnAdLoadFailed?.Invoke(s, info);
            MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += (s, info) => OnAdDisplayed?.Invoke(s, info);
            MaxSdkCallbacks.Rewarded.OnAdClickedEvent += (s, info) => OnAdClicked?.Invoke(s, info);
            MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += (s, info) => OnAdHidden?.Invoke(s, info);
            MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += (s, error, info) => OnAdDisplayFailed?.Invoke(s, error, info);
        }
    }
}