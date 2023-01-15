using System;
using AppodealStack.Monetization.Common;

namespace LittleBitGames.Ads.AdUnits
{
    public class AppodealRevenueEvents : IAdUnitEvents
    {
        public event Action<string, AdInfo> OnAdRevenuePaid;
        public event Action<string, AdInfo> OnAdLoaded;
        public event Action<string, AdErrorInfo> OnAdLoadFailed;
        public event Action<string, AdInfo> OnAdFinished;
        public event Action<string, AdInfo> OnAdClicked;
        public event Action<string, AdInfo> OnAdHidden;
        public event Action<string, AdErrorInfo, AdInfo> OnAdDisplayFailed;

        public AppodealRevenueEvents()
        {
            AppodealCallbacks.RewardedVideo.OnLoaded += (sender, args) => OnAdLoaded?.Invoke(sender.ToString(), new AdInfo());
            AppodealCallbacks.RewardedVideo.OnFailedToLoad += (sender, args) => OnAdLoadFailed?.Invoke(sender.ToString(), new AdErrorInfo());
            AppodealCallbacks.RewardedVideo.OnShowFailed += (sender, args) => OnAdDisplayFailed?.Invoke(sender.ToString(), new AdErrorInfo(), new AdInfo());
            AppodealCallbacks.RewardedVideo.OnClosed += (sender, args) => OnAdHidden?.Invoke(sender.ToString(), new AdInfo());
            AppodealCallbacks.RewardedVideo.OnFinished += (sender, args) => OnAdFinished?.Invoke(sender.ToString(), new AdInfo());
            AppodealCallbacks.RewardedVideo.OnClicked += (sender, args) => OnAdClicked?.Invoke(sender.ToString(), new AdInfo());
            AppodealCallbacks.AdRevenue.OnReceived += (sender, args) =>
                OnAdRevenuePaid?.Invoke(sender.ToString(), new AdInfo(args.Ad));
        }
    }
}