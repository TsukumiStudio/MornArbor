#if USE_MORN_SOUND
using Arbor;
using MornSound;
using UnityEngine;

namespace MornArbor
{
    public sealed class PlaySimpleSoundState : StateBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        public override void OnStateBegin()
        {
            _audioSource.MornPlay(_audioClip);
        }
    }
}
#endif