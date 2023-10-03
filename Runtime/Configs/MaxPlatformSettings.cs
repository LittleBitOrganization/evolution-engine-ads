using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class MaxPlatformSettings
    {
        [SerializeField] private string maxInterAdUnitKey;
    
        [SerializeField] private string maxRewardedAdUnitKey;
        [SerializeField] private string maxBannerAdUnitKey;
        
        public string MaxInterAdUnitKey => maxInterAdUnitKey;

        public string MaxRewardedAdUnitKey => maxRewardedAdUnitKey;
        public string MaxBannerAdUnitKey => maxBannerAdUnitKey;
    }
}