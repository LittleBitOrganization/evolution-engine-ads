using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class MasSettings : IMediationSetting
    {
        [field: SerializeField] public bool IsInter { get; private set; } = true;
        [field: SerializeField] public bool IsRewarded { get; private set; } = true;
        [field: SerializeField] public bool IsBanner { get; private set; } = true;
    }
}