using System;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class AppodealSettings : IMediationSettings
    {
        [field: SerializeField] public string AppIdAndroid { get; private set; }
        [field: SerializeField] public string AppIdIos { get; private set; }
        [field: SerializeField] public bool IsInter { get; private set; } = true;
        [field: SerializeField] public bool IsRewarded { get; private set; } = true;
    }
}