using System;
using LittleBit.Modules.EnvironmentCoreModule;

namespace LittleBit.Modules.Ads
{
    public interface IMediationNetwork
    {
        void ShowRewardedAd(Action<bool> callback);
        event Action OnInitialized;
        event Action<IDataEventAdImpression> OnAdRevenuePaidEvent;
    }
}
