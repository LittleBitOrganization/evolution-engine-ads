using System;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Configs;
using LittleBitGames.Ads.MediationNetworks.MaxSdk;

namespace LittleBitGames.Ads
{
    public class MaxSdkAdsServiceBuilder : IAdsServiceBuilder
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly AdsConfig _adsConfig;
        private IAdUnit _inter, _rewarded;

        public MaxSdkAdsServiceBuilder(AdsConfig adsConfig, ICoroutineRunner coroutineRunner)
        {
            _adsConfig = adsConfig;
            _coroutineRunner = coroutineRunner;
        }

        public void BuildInterAdUnit() =>
            _inter = new MaxSdkInterAd(GetKey(_adsConfig.MaxSettings.MaxInterAdUnitKey), _coroutineRunner);
        
        public void BuildRewardedAdUnit() =>
            _rewarded = new MaxSdkRewardedAd(GetKey(_adsConfig.MaxSettings.MaxRewardedAdUnitKey), _coroutineRunner);
        
        private IAdUnitKey GetKey(string s)
        {
            var key = new AdUnitKey(s);

            if (!key.Validate()) throw new Exception("Max inter ad key is invalid!");

            return key;
        }

        public IAdsService GetResult()
        {
            var initializer = new MaxSdkInitializer(_adsConfig);
            var adsService = new AdsService(initializer, _inter, _rewarded);

            return adsService;
        }
    }
}