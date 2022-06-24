using System;
using System.Collections.Generic;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Configs;
using LittleBitGames.Ads.MediationNetworks.MaxSdk;

namespace LittleBitGames.Ads
{
    internal class MaxSdkAdUnitsFactory
    {
        private readonly ICoroutineRunner _coroutineRunner;

        private readonly AdsConfig _adsConfig;

        public IReadOnlyList<IAdUnit> CreatedAdUnits => _adUnits.AsReadOnly();

        private readonly List<IAdUnit> _adUnits;

        public MaxSdkAdUnitsFactory(ICoroutineRunner coroutineRunner, AdsConfig adsConfig)
        {
            _adUnits = new List<IAdUnit>();

            _adsConfig = adsConfig;
            
            _coroutineRunner = coroutineRunner;
        }

        public IAdUnit CreateInterAdUnit()
        {
            var ad = new MaxSdkInterAd(GetKey(_adsConfig.MaxSettings.MaxInterAdUnitKey), _coroutineRunner);
            
            _adUnits.Add(ad);
            
            return ad;
        }

        public IAdUnit CreateRewardedAdUnit()
        {
            var ad = new MaxSdkRewardedAd(GetKey(_adsConfig.MaxSettings.MaxRewardedAdUnitKey), _coroutineRunner);
            
            _adUnits.Add(ad);

            return ad;
        }

        private IAdUnitKey GetKey(string s)
        {
            var key = new AdUnitKey(s);

            if (!key.Validate()) throw new Exception("Max inter ad key is invalid!");

            return key;
        }
    }
}