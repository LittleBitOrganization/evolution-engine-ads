using LittleBitGames.Environment.Ads;

namespace LittleBitGames.Ads
{
    public interface IAdsServiceBuilder
    {
        void BuildInterAdUnit();
        void BuildRewardedAdUnit();
        void BuildBannerAdUnit();
        IAdsService GetResult();
        IMediationNetworkInitializer Initializer { get; }
        
    }
}