using System;
using System.Collections.Generic;
using Events;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Configs;
using LittleBitGames.Ads.MediationNetworks;
using LittleBitGames.Ads.MediationNetworks.MaxSdk;

namespace LittleBitGames.Ads
{
    public class MaxSdkAdsServiceBuilder : IAdsServiceBuilder
    {
        private readonly AdsConfig _adsConfig;
        private readonly MaxSdkAdUnitsFactory _adUnitsFactory;
        private readonly MaxSdkInitializer _initializer;

        private IAdUnit _inter, _rewarded;
        private AdsService _adsService;
        
        public IReadOnlyList<IAdUnit> CreatedAdUnits => _adUnitsFactory.CreatedAdUnits;

        public IMediationNetworkInitializer Initializer => _initializer;

        public MaxSdkAdsServiceBuilder(AdsConfig adsConfig, ICoroutineRunner coroutineRunner)
        {
            _adUnitsFactory = new MaxSdkAdUnitsFactory(coroutineRunner, adsConfig);
            _adsConfig = adsConfig;
            _initializer = new MaxSdkInitializer(_adsConfig);
        }

        public void BuildInterAdUnit() =>
            _inter = _adUnitsFactory.CreateInterAdUnit();
        
        public void BuildRewardedAdUnit() =>
            _rewarded = _adUnitsFactory.CreateRewardedAdUnit();

        public IAdsService GetResult()
        {
            _adsService = new AdsService(_initializer, _inter, _rewarded);

            return _adsService;
        }
    }
}