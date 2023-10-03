using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class YandexPlatformSettings
    {
        [SerializeField] private string yandexInterAdUnitKey;
    
        [SerializeField] private string yandexRewardedAdUnitKey;
        
        [SerializeField] private string yandexBannerAdUnitKey;

        public string YandexInterAdUnitKey => yandexInterAdUnitKey;
        public string YandexRewardedAdUnitKey => yandexRewardedAdUnitKey;
        public string YandexBannerAdUnitKey => yandexBannerAdUnitKey;
    }
}