using System.Linq;
using MornAspect;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MornArbor
{
    [CreateAssetMenu(fileName = nameof(MornArborGlobalSettings), menuName = "Morn/" + nameof(MornArborGlobalSettings))]
    internal sealed class MornArborGlobalSettings : ScriptableObject
    {
        [SerializeField] private float _fadeInVolumeDuration = 0.3f;
        [SerializeField] private float _fadeOutVolumeDuration = 0.6f;
        internal static MornArborGlobalSettings Instance { get; private set; }
        internal float FadeInVolumeDuration => _fadeInVolumeDuration;
        internal float FadeOutVolumeDuration => _fadeOutVolumeDuration;

        private void OnEnable()
        {
            Instance = this;
            MornArborUtil.Log("Global Settings Loaded");
#if UNITY_EDITOR
            var preloadedAssets = PlayerSettings.GetPreloadedAssets().ToList();
            if (preloadedAssets.Contains(this) && preloadedAssets.Count(x => x is MornArborGlobalSettings) == 1) return;
            preloadedAssets.RemoveAll(x => x is MornArborGlobalSettings);
            preloadedAssets.Add(this);
            PlayerSettings.SetPreloadedAssets(preloadedAssets.ToArray());
            MornArborUtil.Log("Global Settings Added to Preloaded Assets!");
#endif
        }

        private void OnDisable()
        {
            Instance = null;
            MornArborUtil.Log("Global Settings Unloaded");
        }
    }
}