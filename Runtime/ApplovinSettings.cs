using UnityEngine;

namespace LittleBit.Modules.Ads
{
    [CreateAssetMenu(fileName = "ApplovinSettings", menuName = "ApplovinSettings", order = 0)]
    public class ApplovinSettings : ScriptableObject
    {
        [SerializeField] private string _sdkKey;
        [SerializeField] private string _rewardedAdUnitID;

        public string SDKKey => _sdkKey;
        public string RewardedAdUnitID => _rewardedAdUnitID;
    }
}