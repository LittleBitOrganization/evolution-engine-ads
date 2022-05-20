using System;
using LittleBit.Modules.EnvironmentCoreModule;

namespace LittleBit.Modules.Ads
{
    public class Ads
    {
        private readonly IMediationNetwork _mediationNetwork;
        public event Action<IDataEventAdImpression> OnAdRevenuePaidEvent;

        public Ads(IMediationNetwork mediationNetwork)
        {
            _mediationNetwork = mediationNetwork;
            _mediationNetwork.OnAdRevenuePaidEvent += data => OnAdRevenuePaidEvent?.Invoke(data);
        }

        public void ShowRewardedAd(Action<bool> callback)
        {
            _mediationNetwork.ShowRewardedAd(callback);
        }
    }
}