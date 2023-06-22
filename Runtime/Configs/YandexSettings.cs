using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class YandexSettings: IMediationSetting
    {
        [field: SerializeField] public bool IsInter { get; private set; } = true;
        [field: SerializeField] public bool IsRewarded { get; private set; } = true;
        
        [SerializeField] private YandexPlatformSettings settingsAndroid;
        [SerializeField] private YandexPlatformSettings settingsIOS;

        public YandexPlatformSettings PlatformSettings => Application.platform switch
        {
            RuntimePlatform.Android => settingsAndroid,
            RuntimePlatform.IPhonePlayer => settingsIOS,
            _ => settingsAndroid
        };
    }
}