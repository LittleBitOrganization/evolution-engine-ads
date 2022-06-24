using System;

namespace LittleBitGames.Ads.MediationNetworks
{
    public interface IMediationNetworkInitializer
    {
        event Action OnMediationInitialized;

        public void Initialize();
    }
}