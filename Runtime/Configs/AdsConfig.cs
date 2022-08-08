using UnityEditor;
using UnityEngine;

namespace LittleBitGames.Ads.Configs
{
    public class AdsConfig : ScriptableObject
    {
        public const string PathInResources = "Configs";
        
        [SerializeField] private ExecutionMode mode;
        public ExecutionMode Mode => mode;

        [field: SerializeField]
        public MaxSettings MaxSettings { get; private set; }
        
#if UNITY_EDITOR
        [MenuItem("Tools/Configs/Create Ads Config")]
        public static void Create()
        {
            var obj = CreateInstance<AdsConfig>();

            AssetDatabase.CreateAsset(obj, $"Assets/Resources/{PathInResources}/AdsConfig.asset");
            AssetDatabase.SaveAssets();
        }
#endif
    }
}