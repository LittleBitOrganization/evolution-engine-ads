using System;

namespace LittleBitGames.Ads.AdUnits
{
    public class MaxSdkRewardedEvents : IAdUnitEvents
    {
        public event Action<string, AdInfo> OnAdRevenuePaid;
        public event Action<string, AdInfo> OnAdLoaded;
        public event Action<string, AdErrorInfo> OnAdLoadFailed;
        public event Action<string, AdInfo> OnAdFinished;
        public event Action<string, AdInfo> OnAdClicked;
        public event Action<string, AdInfo> OnAdHidden;
        public event Action<string, AdErrorInfo, AdInfo> OnAdDisplayFailed;

        public MaxSdkRewardedEvents()
        {
            MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += (s, info) => OnAdRevenuePaid?.Invoke(s, new AdInfo(info));
            MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += (s, info) => OnAdLoaded?.Invoke(s, new AdInfo(info));
            MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += (s, info) => OnAdLoadFailed?.Invoke(s, new AdErrorInfo(info));
            MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += (s, reward, info) => OnAdFinished?.Invoke(s, null);
            MaxSdkCallbacks.Rewarded.OnAdClickedEvent += (s, info) => OnAdClicked?.Invoke(s, new AdInfo(info));
            MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += (s, info) => OnAdHidden?.Invoke(s, new AdInfo(info));
            MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += (s, error, info) => OnAdDisplayFailed?.Invoke(s, new AdErrorInfo(error), new AdInfo(info));
        }
    }
}