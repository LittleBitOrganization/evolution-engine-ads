using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class YandexPlatformSettings
    {
        [SerializeField] private string yandexInterAdUnitKey;
    
        [SerializeField] private string yandexRewardedAdUnitKey;
        
        public string YandexInterAdUnitKey => yandexInterAdUnitKey;

        public string YandexRewardedAdUnitKey => yandexRewardedAdUnitKey;
    }
}