using System;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Common;
using LittleBitGames.Ads.Factories;

namespace LittleBitGames.Ads.MediationNetworks.AppodealSdk
{
    public abstract class AppodealAdUnit : IAdUnit
    {
        public IAdUnitKey Key { get; }
        public IAdUnitPlace UnitPlace { get; set; }
        public IAdUnitEvents Events { get; }
        public event Action Loaded;
        
        private Action<AdShowInfo> _callback;
        private AdShowInfoFactory _adShowInfoFactory;

        public AppodealAdUnit(IAdUnitKey key, IAdUnitEvents events, ICoroutineRunner coroutineRunner)
        {
            Key = key;
            Events = events;
        }
        
        protected abstract bool IsAdReady();

        protected abstract void ShowAd();
        
        public abstract void Load();

        private void ObserveAppodealCallback()
        {
            Events.OnAdLoaded += OnAdLoaded;
            Events.OnAdLoadFailed += OnAdLoadFailed;
            Events.OnAdHidden += OnAdHiddenEvent;
            Events.OnAdDisplayFailed += OnAdDisplayFailed;
            Events.OnAdFinished += OnAdFinished;
        }

        public virtual void OnAdLoaded(string adUnitId, AppodealAdRevenue adInfo)
        {
            Loaded?.Invoke();
        }
        public abstract void OnAdLoadFailed(string adUnitId, MaxSdkBase.ErrorInfo errorInfo);

        public virtual void OnAdDisplayFailed(string adUnitId, MaxSdkBase.ErrorInfo errorInfo,
            AppodealAdRevenue adInfo)
        {
            InvokeCallback(false);
        }

        public virtual void OnAdFinished(string arg1, AppodealAdRevenue arg2)
        {
            InvokeCallback(true);
        }

        public abstract void OnAdHiddenEvent(string adUnitId, AppodealAdRevenue adInfo);
        
        private void InvokeCallback(bool success)
        {
            var adShowInfo = _adShowInfoFactory.Create(success);
            _callback?.Invoke(adShowInfo);
        }
        public void Show(IAdUnitPlace from, Action<AdShowInfo> callback)
        {
            UnitPlace = from;

            _adShowInfoFactory = new AdShowInfoFactory(Key, from);
            
            _callback = callback;

            if (IsAdReady()) ShowAd();
        }

        public bool IsReady() => IsAdReady();
    }
}