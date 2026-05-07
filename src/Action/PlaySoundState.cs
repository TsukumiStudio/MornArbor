using Arbor;
﻿using MornLib;
using UnityEngine;
using System;

namespace MornLib
{
    [Serializable]
    internal sealed class PlaySoundState : StateBehaviour
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