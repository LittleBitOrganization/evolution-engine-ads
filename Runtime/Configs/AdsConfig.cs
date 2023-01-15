using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    public class AdsConfig : ScriptableObject
    {
        public const string PathInResources = "Configs/AdsConfig";
        
        [SerializeField] private ExecutionMode mode;
        public ExecutionMode Mode => mode;
        
        public bool IsInter => GetMediationSettings.IsInter;
        
        public bool IsRewarded => GetMediationSettings.IsRewarded;

        [Dropdown("_getMediationSettings")] public IMediationSettings GetMediationSettings;
        
        private DropdownList<IMediationSettings> _getMediationSettings()
        {
            return new DropdownList<IMediationSettings>()
            {
                { "Appodeal",   MaxSettings },
                { "MaxSDK",    AppodealSettings }
            };
        }
        
        [field: SerializeField]
        public MaxSettings MaxSettings { get; private set; }
        
        [field: SerializeField]
        public AppodealSettings AppodealSettings { get; private set; }


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
}