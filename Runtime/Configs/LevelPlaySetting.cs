using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class LevelPlaySetting: IMediationSetting
    {
        [field: SerializeField] public bool IsInter { get; private set; } = true;
        [field: SerializeField] public bool IsRewarded { get; private set; } = true;
        [field: SerializeField] public bool IsBanner { get; private set; } = true;

        [SerializeField] private LevelPlayPlatformSettings settingsAndroid;
        [SerializeField] private LevelPlayPlatformSettings settingsIOS;

        public LevelPlayPlatformSettings PlatformSettings => Application.platform switch
        {
            RuntimePlatform.Android => settingsAndroid,
            RuntimePlatform.IPhonePlayer => settingsIOS,
            _ => settingsAndroid
        };
    }
}