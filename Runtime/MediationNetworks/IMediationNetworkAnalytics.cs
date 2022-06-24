using System;
using Events;

namespace LittleBitGames.Ads.MediationNetworks
{
    public interface IMediationNetworkAnalytics
    {
        event Action<IDataEventAdImpression> OnAdRevenuePaidEvent;
    }
}