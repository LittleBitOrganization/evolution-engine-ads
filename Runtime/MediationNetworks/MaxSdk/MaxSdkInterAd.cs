using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;

namespace LittleBitGames.Ads.MediationNetworks.MaxSdk
{
    public sealed class MaxSdkInterAd : MaxAdUnit
    {
        private readonly IAdUnitKey _key;

        public MaxSdkInterAd(IAdUnitKey key, ICoroutineRunner coroutineRunner) : base(key,
            new MaxSdkInterEvents(), coroutineRunner) => _key = key;

        protected override bool IsAdReady(IAdUnitKey key) => global::MaxSdk.IsInterstitialReady(_key.StringValue);

        protected override void ShowAd(IAdUnitKey key) => global::MaxSdk.ShowInterstitial(_key.StringValue);
        public override void Load() => global::MaxSdk.LoadInterstitial(_key.StringValue);
    }
}