using System;

namespace LittleBitGames.Ads.AdUnits
{
    public interface IAdUnitEvents
    {
        public event Action<string, AdInfo> OnAdRevenuePaid;
        public event Action<string, AdInfo> OnAdLoaded;
        public event Action<string, AdErrorInfo> OnAdLoadFailed;
        public event Action<string, AdInfo> OnAdFinished;
        public event Action<string, AdInfo> OnAdClicked;
        public event Action<string, AdInfo> OnAdHidden;
        public event Action<string, AdErrorInfo, AdInfo> OnAdDisplayFailed;
    }
}