using System.Collections.Generic;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Environment.Ads;

namespace LittleBitGames.Ads
{
    public interface IAdsServiceBuilder
    {
        void BuildInterAdUnit();
        void BuildRewardedAdUnit();
        IAdsService GetResult();
        IReadOnlyList<IAdUnit> CreatedAdUnits { get; }
        
        IMediationNetworkInitializer Initializer { get; }
        
    }
}