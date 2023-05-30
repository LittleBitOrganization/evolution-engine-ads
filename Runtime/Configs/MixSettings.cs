using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class MixSettings : IMediationSetting
    {
        [field: SerializeField] public bool IsInter { get; private set; } = true;
        [field: SerializeField] public bool IsRewarded { get; private set; } = true;
    }
}