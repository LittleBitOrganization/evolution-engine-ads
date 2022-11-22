using System;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Environment.Ads;

namespace LittleBitGames.Ads
{
    public class CommandAdsFactory
    {
        private readonly IAdsService _adsService;
        private SkipAdsCondition _skipAdsCondition;
        public event Action<AdType> AdShowed;

        public CommandAdsFactory(IAdsService adsService, SkipAdsCondition skipAdsCondition)
        {
            _adsService = adsService;
            _skipAdsCondition = skipAdsCondition;
        }

        public CommandAds ShowReward(IAdUnitPlace place)
        {
            return new CommandAds(_adsService, AdType.Rewarded, place, _skipAdsCondition, success => OnAdShow(success, AdType.Rewarded));
        }

        public CommandAds ShowInter(IAdUnitPlace place)
        {
            return new CommandAds(_adsService, AdType.Inter, place, _skipAdsCondition, success => OnAdShow(success, AdType.Rewarded));
        }

        private void OnAdShow(bool success, AdType adType)
        {
            if (success) AdShowed?.Invoke(adType);
        }
    }
}