using System;
using System.Collections.Generic;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Environment.Ads;

namespace LittleBitGames.Ads
{
    public interface IAdsService
    {
        void Run();
        void ShowAd(AdType adType, IAdUnitPlace from, Action<AdShowInfo> callback);
        
        IMediationNetworkInitializer Initializer { get; }
        
        IReadOnlyList<IAdUnit> AdUnits { get; }
        
        IMediationNetworkAnalytics Analytics { get; }
    }
}