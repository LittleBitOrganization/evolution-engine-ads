using System;
using System.Collections.Generic;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Environment.Ads;

namespace LittleBitGames.Ads
{
    public class AdsService : IAdsService
    {
        private readonly IAdUnit _interAd;
        private readonly IAdUnit _rewardedAd;

        private readonly IMediationNetworkInitializer _initializer;

        public IMediationNetworkInitializer Initializer => _initializer;
        public IReadOnlyList<IAdUnit> AdUnits { get; }

        public AdsService(IMediationNetworkInitializer initializer, IAdUnit interAd, IAdUnit rewardedAd)
        {
            _initializer = initializer;
            _rewardedAd = rewardedAd;
            _interAd = interAd;
            
            AdUnits = new[] {interAd, rewardedAd};
        }

        public void Run()
        {
            _initializer.OnMediationInitialized += LoadAds;
            _initializer.Initialize();
        }

        public void ShowAd(AdType adType, IAdUnitPlace from, Action<AdShowInfo> callback)
        {
            switch (adType)
            {
                case AdType.Inter:
                    _interAd?.Show(from, callback);
                    break;
                case AdType.Rewarded:
                    _rewardedAd?.Show(from, callback);
                    break;
            }
        }
        
        private void LoadAds()
        {
            _interAd?.Load();
            _rewardedAd?.Load();
        }
    }
}