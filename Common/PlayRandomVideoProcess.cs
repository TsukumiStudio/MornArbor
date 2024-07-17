using Arbor;
using UnityEngine;
using UnityEngine.Video;

namespace MornArbor
{
    public class PlayRandomVideoProcess : StateBehaviour, IProcessState
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private VideoClip[] _clips;
        [SerializeField] private StateLink _nextStateLink;
        public bool IsActive => _videoPlayer.isPlaying;

        public override void OnStateBegin()
        {
            _videoPlayer.clip = _clips[Random.Range(0, _clips.Length)];
            _videoPlayer.Play();
        }
    }
}