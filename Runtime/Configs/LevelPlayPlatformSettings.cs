using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class LevelPlayPlatformSettings
    {
        [SerializeField] private string _appKey;
        [SerializeField] private string _rewardAdunitId;
        [SerializeField] private string _interstitialAdunitId;
        [SerializeField] private string _bannerAdunitId;

        public string AppKey => _appKey;

        public string RewardAdunitId => _rewardAdunitId;

        public string InterstitialAdunitId => _interstitialAdunitId;

        public string BannerAdunitId => _bannerAdunitId;
    }
}