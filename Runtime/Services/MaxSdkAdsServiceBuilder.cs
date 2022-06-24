using System;
using System.Collections.Generic;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Configs;
using LittleBitGames.Ads.MediationNetworks.MaxSdk;

namespace LittleBitGames.Ads
{
    public class MaxSdkAdsServiceBuilder : IAdsServiceBuilder
    {
        private readonly AdsConfig _adsConfig;
        private readonly MaxSdkAdUnitsFactory _adUnitsFactory;

        private IAdUnit _inter, _rewarded;
        public IReadOnlyList<IAdUnit> CreatedAdUnits => _adUnitsFactory.CreatedAdUnits;

        public MaxSdkAdsServiceBuilder(AdsConfig adsConfig, ICoroutineRunner coroutineRunner)
        {
            _adUnitsFactory = new MaxSdkAdUnitsFactory(coroutineRunner, adsConfig);
            _adsConfig = adsConfig;
        }

        public void BuildInterAdUnit() =>
            _inter = _adUnitsFactory.CreateInterAdUnit();
        
        public void BuildRewardedAdUnit() =>
            _rewarded = _adUnitsFactory.CreateRewardedAdUnit();

        public IAdsService GetResult()
        {
            var initializer = new MaxSdkInitializer(_adsConfig);
            var adsService = new AdsService(initializer, _inter, _rewarded);

            return adsService;
        }
    }
}