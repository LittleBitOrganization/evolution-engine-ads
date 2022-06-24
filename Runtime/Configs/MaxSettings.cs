using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class MaxSettings
    {
        [Header("MaxSdk")] [SerializeField] private string maxSdkKey;

        [SerializeField] private string maxInterAdUnitKey;
    
        [SerializeField] private string maxRewardedAdUnitKey;
    
        public string MaxSdkKey => maxSdkKey;
    
        public string MaxInterAdUnitKey => maxInterAdUnitKey;

        public string MaxRewardedAdUnitKey => maxRewardedAdUnitKey;
    }
}