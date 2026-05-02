using MornLib;
using UnityEngine;
using System;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal sealed class PlaySoundState : MornStateBehaviour
#else
    [Serializable]
    internal sealed class PlaySoundState : StateBehaviour
#endif
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        public override void OnStateBegin()
        {
            _audioSource.clip = _audioClip;
            _audioSource.Play();
        }
    }
}