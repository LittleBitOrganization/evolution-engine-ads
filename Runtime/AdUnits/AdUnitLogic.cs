using System;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.Common;
using LittleBitGames.Ads.Factories;

namespace LittleBitGames.Ads.AdUnits
{
    public abstract class AdUnitLogic : IAdUnit
    {
        private Action<AdShowInfo> _callback;

        private AdShowInfoFactory _adShowInfoFactory;

        private readonly RetryTimer _retryTimer;

        public bool IsReady() => IsAdReady();
        public IAdUnitKey Key { get; }
        public IAdUnitPlace UnitPlace { get; set; }
        public IAdUnitEvents Events { get; }
        public event Action Loaded;
        public event Action <IAdInfo> OnAdRevenuePaid;

        public AdUnitLogic(IAdUnitKey key, IAdUnitEvents events, ICoroutineRunner coroutineRunner)
        {
            Key = key;
            Events = events;

            _retryTimer = new RetryTimer(coroutineRunner, Load);
            ObserveCallback();
        }
        
        public void Show(IAdUnitPlace from, Action<AdShowInfo> callback)
        {
            UnitPlace = from;

            _adShowInfoFactory = new AdShowInfoFactory(Key, from);
            
            _callback = callback;

            if (IsAdReady()) ShowAd();
        }

        protected abstract bool IsAdReady();
        protected abstract void ShowAd();
        public abstract void Load();
        

        private void ObserveCallback()
        {
            Events.OnAdLoaded += OnAdLoaded;
            Events.OnAdLoadFailed += OnAdLoadFailed;
            Events.OnAdHidden += OnAdHiddenEvent;
            Events.OnAdDisplayFailed += OnAdDisplayFailed;
            Events.OnAdFinished += OnAdFinished;
            Events.OnAdRevenuePaid += EventsOnOnAdRevenuePaid;
        }

        private void EventsOnOnAdRevenuePaid(string arg1, IAdInfo arg2)
        {
            OnAdRevenuePaid?.Invoke(arg2);
        }

        private void OnAdFinished(string arg1, IAdInfo arg2) => Finish(true);
        
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
        
        private void OnAdLoaded(string adUnitId, IAdInfo adInfo)
        {
            _retryTimer.Reset();
            
            Loaded?.Invoke();
        }

        private void OnAdLoadFailed(string adUnitId, IAdErrorInfo errorInfo) =>
            _retryTimer.NextAttempt();

        private void OnAdDisplayFailed(string adUnitId, IAdErrorInfo errorInfo,
            IAdInfo adInfo) => Finish(false);

        private void OnAdHiddenEvent(string adUnitId, IAdInfo adInfo) =>
            Finish(false);
        

    }
}