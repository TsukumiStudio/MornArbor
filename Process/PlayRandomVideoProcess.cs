using Arbor;
using UnityEngine;
using UnityEngine.Video;

namespace MornArbor.Process
{
    public class PlayRandomVideoProcess : ProcessBase
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private VideoClip[] _clips;
        [SerializeField] private StateLink _nextStateLink;
        public override float Progress => _videoPlayer ? Mathf.Clamp01(_videoPlayer.frame / (float)_videoPlayer.frameCount) : 1f;

        public override void OnStateBegin()
        {
            _videoPlayer.clip = _clips[Random.Range(0, _clips.Length)];
            _videoPlayer.Play();
        }
    }
}