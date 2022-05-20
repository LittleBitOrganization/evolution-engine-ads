using System;
using System.Collections;
using LittleBit.Modules.CoreModule;
using UnityEngine;
using UnityEngine.Events;

namespace LittleBit.Modules.Ads
{
    public partial class MaxSdkWrapper
    {
        public class RewardedAdUnit : IAdUnit
        {
            private string _id;
            private int _retryAttempt;

            private ICoroutineRunner coroutineRunner;

            public event Action<bool> OnFinish;

            public RewardedAdUnit(ICoroutineRunner coroutineRunner)
            {
                this.coroutineRunner = coroutineRunner;
            }

            public void Show()
            {
                if (MaxSdk.IsRewardedAdReady(_id))
                    MaxSdk.ShowRewardedAd(_id);
            }

            public void Initialize(ApplovinSettings applovinSettings)
            {
                MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
                MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
                MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
                MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
                MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;
                MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdHiddenEvent;
                MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
                MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

                _id = applovinSettings.RewardedAdUnitID;
                LoadRewardedAd();
            }

            private void LoadRewardedAd()
            {
                MaxSdk.LoadRewardedAd(_id);
            }

            private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
            {
                _retryAttempt = 0;
            }

            private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
            {
                _retryAttempt++;

                var retryDelay = Math.Pow(2, Math.Min(6, _retryAttempt));

                coroutineRunner.StartCoroutine(WaitForSeconds((float) retryDelay, LoadRewardedAd));
            }

            private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
            {
            }

            private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo,
                MaxSdkBase.AdInfo adInfo)
            {
                LoadRewardedAd();

                OnFinish?.Invoke(false);
                OnFinish = null;
            }

            private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
            {
            }    

            private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
            {
                LoadRewardedAd();

                OnFinish?.Invoke(false);
                OnFinish = null;
            }

            private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward,
                MaxSdkBase.AdInfo adInfo)
            {
                OnFinish?.Invoke(true);
                OnFinish = null;
            }

            private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
            {
            }

            private IEnumerator WaitForSeconds(float seconds, UnityAction callback)
            {
                yield return new WaitForSecondsRealtime(seconds);

                callback?.Invoke();
            }
        }
    }
}