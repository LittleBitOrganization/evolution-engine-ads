using LittleBitGames.Environment.Ads;

namespace LittleBitGames.Ads
{
    public interface IAdsServiceBuilder
    {
        void BuildInterAdUnit();
        void BuildRewardedAdUnit();
        IAdsService GetResult();
        IMediationNetworkInitializer Initializer { get; }
        
    }
}