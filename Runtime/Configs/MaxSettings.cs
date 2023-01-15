using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class MaxSettings : IMediationSettings
    {
        [field: SerializeField] public string MaxSdkKey { get; private set; }
        [field: SerializeField] public bool IsInter { get; private set; } = true;
        [field: SerializeField] public bool IsRewarded { get; private set; } = true;

        [SerializeField] private MaxPlatformSettings settingsAndroid;
        [SerializeField] private MaxPlatformSettings settingsIOS;

        public MaxPlatformSettings PlatformSettings => Application.platform switch
        {
            RuntimePlatform.Android => settingsAndroid,
            RuntimePlatform.IPhonePlayer => settingsIOS,
            _ => settingsAndroid
        };
    }

    public interface IMediationSettings
    {
        public bool IsInter { get; }
        public bool IsRewarded { get; }
    }
}