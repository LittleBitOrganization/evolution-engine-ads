using LittleBitGames.Ads;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.MediationNetworks.AppodealSdk;
using LittleBitGames.Environment.Ads;

namespace Services
{
    public class AppodealAdsServiceBuilder : IAdsServiceBuilder
    {
        private readonly AppodealInitializer _initializer;
        private IAdUnit _inter, _rewarded;
        public IMediationNetworkInitializer Initializer => _initializer;
        
        public void BuildInterAdUnit()
        {
            
        }

        public void BuildRewardedAdUnit()
        {
            
        }

        public IAdsService QuickBuild()
        {
            if (!string.IsNullOrEmpty(_adsConfig.MaxSettings.PlatformSettings.MaxInterAdUnitKey) && _adsConfig.IsInter) 
                BuildInterAdUnit();
            if (!string.IsNullOrEmpty(_adsConfig.MaxSettings.PlatformSettings.MaxRewardedAdUnitKey) && _adsConfig.IsRewarded) 
                BuildRewardedAdUnit();

            return GetResult();
        }
        
        public void BuildInterAdUnit() =>
            _inter = _adUnitsFactory.CreateInterAdUnit();

        public void BuildRewardedAdUnit() =>
            _rewarded = _adUnitsFactory.CreateRewardedAdUnit();
        
        public IAdsService GetResult() => new AdsService(_initializer, _inter, _rewarded);
    }
}