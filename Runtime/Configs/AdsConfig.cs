using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using NaughtyAttributes;

namespace LittleBitGames.Ads.Configs
{
    [Serializable]
    public class AdsConfig : ScriptableObject
    {
        public const string PathInResources = "Configs/AdsConfig";
        
        [SerializeField] private ExecutionMode mode;
        [SerializeField] private SettingsEnum _settings;
        public ExecutionMode Mode => mode;
        public SettingsEnum Settings => _settings;
        
        public bool IsInter => GetMediationSettings().IsInter;
        public bool IsRewarded => GetMediationSettings().IsRewarded;

        private IMediationSetting GetMediationSettings()
        {
            switch (_settings)
            {
                case SettingsEnum.MaxSDK:
                    return MaxSettings;
                case SettingsEnum.MixSDK:
                    return MixSettings;
                case SettingsEnum.YandexSDK:
                    return YandexSettings;
            }

            return null;
        }
        
        [field: SerializeField, ShowIf("Settings", SettingsEnum.MaxSDK)]
        public MaxSettings MaxSettings { get; private set; }
        [field: SerializeField, ShowIf("Settings", SettingsEnum.MixSDK)]
        public MixSettings MixSettings { get; private set; }
        [field: SerializeField, ShowIf("Settings", SettingsEnum.YandexSDK)]
        public YandexSettings YandexSettings { get; private set; }
        
        [field: SerializeField] public UMPSettings UmpSettings { get; private set; }
        
#if UNITY_EDITOR
        [MenuItem("Tools/Configs/Create Ads Config")]
        public static void Create()
        {
            var obj = CreateInstance<AdsConfig>();
            
            var fullPath = $"Assets/Resources/{PathInResources}";
            string[] fullPathInParts = fullPath.Split("/");
            string fillablePath = "Assets";
            
            for (int i = 1; i < fullPathInParts.Length - 1; i++)
            {
                if (!AssetDatabase.IsValidFolder($"{fillablePath}/{fullPathInParts[i]}"))
                    AssetDatabase.CreateFolder($"{fillablePath}", $"{fullPathInParts[i]}");
                
                fillablePath += "/" + fullPathInParts[i];
            }

            AssetDatabase.CreateAsset(obj, $"{fullPath}.asset");
            AssetDatabase.SaveAssets();
        }
#endif
        
    }
    
    [Serializable]
    public class UMPSettings
    {
        [SerializeField] private bool _isEnable = false;
        [SerializeField] private List<string> _idTestDevices;
        public bool IsEnable => _isEnable;

        public IReadOnlyList<string> IDTestDevices => _idTestDevices;
    }
}