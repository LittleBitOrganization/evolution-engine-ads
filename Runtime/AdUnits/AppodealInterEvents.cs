using System;
using AppodealStack.Monetization.Common;

namespace LittleBitGames.Ads.AdUnits
{
    public class AppodealInterEvents : IAdUnitEvents
    {
        public event Action<string, AdInfo> OnAdRevenuePaid;
        public event Action<string, AdInfo> OnAdLoaded;
        public event Action<string, AdErrorInfo> OnAdLoadFailed;
        public event Action<string, AdInfo> OnAdFinished;
        public event Action<string, AdInfo> OnAdClicked;
        public event Action<string, AdInfo> OnAdHidden;
        public event Action<string, AdErrorInfo, AdInfo> OnAdDisplayFailed;

        public AppodealInterEvents()
        {
            AppodealCallbacks.Interstitial.OnLoaded += (sender, args) => OnAdLoaded?.Invoke(sender.ToString(), new AdInfo());
            AppodealCallbacks.Interstitial.OnFailedToLoad += (sender, args) => OnAdLoadFailed?.Invoke(sender.ToString(), null);
            AppodealCallbacks.Interstitial.OnShown += (sender, args) => OnAdFinished?.Invoke(sender.ToString(), new AdInfo());
            AppodealCallbacks.Interstitial.OnShowFailed += (sender, args) => OnAdDisplayFailed?.Invoke(sender.ToString(), null, null);
            AppodealCallbacks.Interstitial.OnClosed += (sender, args) => OnAdHidden?.Invoke(sender.ToString(), new AdInfo());
            AppodealCallbacks.Interstitial.OnClicked += (sender, args) => OnAdClicked?.Invoke(sender.ToString(), new AdInfo());
            AppodealCallbacks.AdRevenue.OnReceived += (sender, args) =>
                OnAdRevenuePaid?.Invoke(sender.ToString(), new AdInfo(args.Ad));
        }
    }
}