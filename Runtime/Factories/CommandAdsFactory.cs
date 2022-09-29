using System;
using LittleBitGames.Environment.Ads;

namespace LittleBitGames.Ads
{
    public class CommandAdsFactory
    {
        private readonly IAdsService _adsService;
        private SkipAdsCondition _skipAdsCondition;
        public event Action AdShowed;

        public CommandAdsFactory(IAdsService adsService, SkipAdsCondition skipAdsCondition)
        {
            _adsService = adsService;
            _skipAdsCondition = skipAdsCondition;
        }

        public CommandAds ShowReward(IAdUnitPlace place)
        {
            return new CommandAds(_adsService, AdType.Rewarded, place, _skipAdsCondition, OnAdShow());
        }

        public CommandAds ShowInter(IAdUnitPlace place)
        {
            return new CommandAds(_adsService, AdType.Inter, place, _skipAdsCondition, OnAdShow());
        }

        private void OnAdShow(bool success)
        {
            if (success) AdShowed?.Invoke();
        }
    }
}