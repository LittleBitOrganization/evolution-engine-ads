using System;
using Events;
using LittleBitGames.Ads.AdUnits;

namespace LittleBitGames.Ads
{
    public interface IAdsService
    {
        void Run();
        void ShowAd(AdType adType, IAdUnitPlace from, Action<AdShowInfo> callback);
    }
}