using System;
using System.Collections;
using LittleBit.Modules.CoreModule;
using UnityEngine;
using UnityEngine.Events;

namespace LittleBitGames.Ads.Common
{
    public class RetryTimer
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly Action _callback;

        private int _retryAttempt;

        public RetryTimer(ICoroutineRunner coroutineRunner, Action callback)
        {
            _callback = callback;
            _coroutineRunner = coroutineRunner;
        }

        public void NextAttempt()
        {
            var retryDelay = Math.Pow(2, Math.Min(6, _retryAttempt));

            _coroutineRunner.StartCoroutine(WaitForSeconds((float) retryDelay, _callback.Invoke));
        }

        public void Reset() => _retryAttempt = 0;

        private IEnumerator WaitForSeconds(float seconds, UnityAction callback)
        {
            yield return new WaitForSecondsRealtime(seconds);

            callback?.Invoke();
        }
    }
}