using System;

namespace LittleBitGames.Ads.AdUnits
{
    public interface IAdUnitEvents
    {
        public event Action<string, MaxSdkBase.AdInfo> OnAdRevenuePaid;
        public event Action<string, MaxSdkBase.AdInfo> OnAdLoaded;
        public event Action<string, MaxSdkBase.ErrorInfo> OnAdLoadFailed;
        public event Action<string, MaxSdkBase.AdInfo> OnAdDisplayed;
        public event Action<string, MaxSdkBase.AdInfo> OnAdClicked;
        public event Action<string, MaxSdkBase.AdInfo> OnAdHidden;
        public event Action<string, MaxSdkBase.ErrorInfo, MaxSdkBase.AdInfo> OnAdDisplayFailed;

    }
}