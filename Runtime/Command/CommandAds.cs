using System;
using LittleBitGames.Environment.Ads;

namespace LittleBitGames.Ads
{
    public class CommandAds
    {
        private readonly IAdsService _adsService;
        private readonly AdType _type;
        private readonly IAdUnitPlace _place;
        private readonly SkipAdsCondition _skipAdsCondition;

        public CommandAds(IAdsService adsService, AdType type, IAdUnitPlace place, SkipAdsCondition skipAdsCondition)
        {
            _adsService = adsService;
            _type = type;
            _place = place;
            _skipAdsCondition = skipAdsCondition;
        }

        public void Execute(Action<bool> onShowed)
        {
            if (_skipAdsCondition.Invoke())
            {
                onShowed?.Invoke(true);
            }
            else
            {
                _adsService.ShowAd(_type, _place, info => { onShowed?.Invoke(info.Success); });
            }
        }
    }
}