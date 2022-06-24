using System.Collections.Generic;
using LittleBitGames.Ads.AdUnits;

namespace LittleBitGames.Ads
{
    public interface IAdsServiceBuilder
    {
        void BuildInterAdUnit();
        void BuildRewardedAdUnit();
        IAdsService GetResult();
        IReadOnlyList<IAdUnit> CreatedAdUnits { get; }
    }
}