using MornLib;
using UnityEngine;

namespace MornLib
{
#if USE_MORNSTATE
    internal sealed class PlaySoundState : MornStateBehaviour
#else
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