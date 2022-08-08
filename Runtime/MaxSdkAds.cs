using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.Configs;
using LittleBitGames.Ads.MediationNetworks.MaxSdk;
using UnityEngine;

namespace LittleBitGames.Ads
{
    public class MaxSdkAds
    {
        private readonly MaxSdkAdsServiceBuilder _builder;
        private readonly AdsConfig _adsConfig;
        private readonly ICreator _creator;

        public MaxSdkAds(ICreator creator, ICoroutineRunner coroutineRunner)
        {
            _creator = creator;
            
            _adsConfig = Resources.Load<AdsConfig>(AdsConfig.PathInResources);
            
            _builder = creator.Instantiate<MaxSdkAdsServiceBuilder>(_adsConfig);
        }

        public IAdsService CreateAdsService(bool useAnalytics)
        {
            var adsService = _builder.QuickBuild();

            if (useAnalytics) _creator.Instantiate<MaxSdkAnalytics>(adsService);

            adsService.Run();

            return adsService;
        }
    }
}