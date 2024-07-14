using MornAspect;
using UnityEngine;

namespace MornArbor
{
    [CreateAssetMenu(fileName = nameof(MornArborGlobalSettings), menuName = "Morn/" + nameof(MornArborGlobalSettings))]
    internal sealed class MornArborGlobalSettings : ScriptableObject
    {
        [SerializeField] private float _fadeInVolumeDuration = 0.5f;
        [SerializeField] private float _fadeOutVolumeDuration = 0.5f;
        internal static MornArborGlobalSettings Instance { get; private set; }
        internal float FadeInVolumeDuration => _fadeInVolumeDuration;
        internal float FadeOutVolumeDuration => _fadeOutVolumeDuration;

        private void OnEnable()
        {
            Instance = this;
            MornArborUtil.Log("Global Settings Loaded");
        }

        private void OnDisable()
        {
            Instance = null;
            MornArborUtil.Log("Global Settings Unloaded");
        }
    }
}