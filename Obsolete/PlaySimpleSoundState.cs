#if USE_MORN_SOUND
using System;
using Arbor;
using MornSound;
using UnityEngine;

namespace MornArbor
{
    [Obsolete("MornSoundPlayOneShotStateやMornSoundPlayOneShotStateを使用してください。")]
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