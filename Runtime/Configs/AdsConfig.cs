using UnityEditor;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    public class AdsConfig : ScriptableObject
    {
        [SerializeField] private ExecutionMode mode;
        public ExecutionMode Mode => mode;

        [SerializeField] private MaxSettings _maxSettings;

        public MaxSettings MaxSettings => _maxSettings;

#if UNITY_EDITOR
        [MenuItem("Tools/Configs/Create Ads Config")]
        public static void Create()
        {
            var obj = CreateInstance<AdsConfig>();

            AssetDatabase.CreateAsset(obj, "Assets/Resources/Configs/AdsConfig.asset");
            AssetDatabase.SaveAssets();
        }
#endif
    }
}