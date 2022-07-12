using System;
using Events;
using LittleBitGames.Ads.AdUnits;

namespace LittleBitGames.Ads.MediationNetworks
{
    public interface IMediationNetworkAnalytics
    {
        event Action<IDataEventAdImpression, AdType> OnAdRevenuePaidEvent;
    }
}