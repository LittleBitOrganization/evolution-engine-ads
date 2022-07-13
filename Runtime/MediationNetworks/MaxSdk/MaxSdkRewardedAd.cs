using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;

namespace LittleBitGames.Ads.MediationNetworks.MaxSdk
{
    public sealed class MaxSdkRewardedAd : MaxAdUnit
    {
        private readonly IAdUnitKey _key;

        public MaxSdkRewardedAd(IAdUnitKey key, ICoroutineRunner coroutineRunner) : base(key,
            new MaxSdkRewardedEvents(), coroutineRunner) => _key = key;

        protected override bool IsAdReady(IAdUnitKey key) => global::MaxSdk.IsRewardedAdReady(_key.StringValue);

        protected override void ShowAd(IAdUnitKey key) => global::MaxSdk.ShowRewardedAd(_key.StringValue);
        public override void Load() => global::MaxSdk.LoadRewardedAd(_key.StringValue);
    }
}