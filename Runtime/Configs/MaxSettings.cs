using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class MaxSettings
    {
        [field: SerializeField] public string MaxSdkKey { get; private set; }
        
        [SerializeField] private MaxPlatformSettings settingsAndroid;
        [SerializeField] private MaxPlatformSettings settingsIOS;
        public MaxPlatformSettings PlatformSettings => Application.platform switch
        {
            RuntimePlatform.Android => settingsAndroid,
            RuntimePlatform.IPhonePlayer => settingsIOS,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}