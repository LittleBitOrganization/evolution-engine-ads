using System;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Common;
using LittleBitGames.Ads.Factories;

namespace LittleBitGames.Ads.MediationNetworks.MaxSdk
{
    public abstract class MaxAdUnit : IAdUnit
    {
        public IAdUnitPlace UnitPlace { get; set; }

        public IAdUnitEvents Events { get; }

        public IAdUnitKey Key { get; }

        private Action<AdShowInfo> _callback;

        private AdShowInfoFactory _adShowInfoFactory;

        private readonly RetryTimer _retryTimer;

        public MaxAdUnit(IAdUnitKey key, IAdUnitEvents events, ICoroutineRunner coroutineRunner)
        {
            Key = key;
            Events = events;

            _retryTimer = new RetryTimer(coroutineRunner, Load);

            ObserveMaxSdkCallback();
        }

        protected abstract bool IsAdReady(IAdUnitKey key);
        
        protected abstract void ShowAd(IAdUnitKey key);

        private void ObserveMaxSdkCallback()
        {
            Events.OnAdLoaded += OnAdLoaded;
            Events.OnAdLoadFailed += OnAdLoadFailed;
            Events.OnAdHidden += OnAdHiddenEvent;
            Events.OnAdDisplayFailed += OnAdDisplayFailed;
        }

        public void Show(IAdUnitPlace from, Action<AdShowInfo> callback)
        {
            UnitPlace = from;

            _adShowInfoFactory = new AdShowInfoFactory(Key, from);;
            _callback = callback;

            if (IsAdReady(Key)) ShowAd(Key);
        }

        public void Load() => global::MaxSdk.LoadInterstitial(Key.StringValue);

        private void Finish(bool success)
        {
            Load();

            InvokeCallback(success);
        }

        private void InvokeCallback(bool success)
        {
            var adShowInfo = _adShowInfoFactory.Create(success);
            _callback?.Invoke(adShowInfo);
        }

        private void OnAdLoaded(string adUnitId, MaxSdkBase.AdInfo adInfo) =>
            _retryTimer.Reset();

        private void OnAdLoadFailed(string adUnitId, MaxSdkBase.ErrorInfo errorInfo) =>
            _retryTimer.NextAttempt();

        private void OnAdDisplayFailed(string adUnitId, MaxSdkBase.ErrorInfo errorInfo,
            MaxSdkBase.AdInfo adInfo) => Finish(false);

        private void OnAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) =>
            Finish(false);
    }
}