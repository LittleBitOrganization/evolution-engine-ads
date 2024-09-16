using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class PlaygapSetting: IMediationSetting
    {
        [field: SerializeField] public string PlaygapApiKey { get; private set; }
        [field: SerializeField] public string MaxSdkKey { get; private set; }
        [field: SerializeField] public bool IsInter { get; private set; } = true;
        [field: SerializeField] public bool IsRewarded { get; private set; } = true;
        [field: SerializeField] public bool IsBanner { get; private set; } = true;

        [SerializeField] private MaxPlatformSettings settingsAndroid;
        [SerializeField] private MaxPlatformSettings settingsIOS;

        public MaxPlatformSettings PlatformSettings => Application.platform switch
        {
            RuntimePlatform.Android => settingsAndroid,
            RuntimePlatform.IPhonePlayer => settingsIOS,
            _ => settingsAndroid
        };
    }
}