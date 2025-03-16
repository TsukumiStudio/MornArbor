using Arbor;
using UnityEngine;
using UnityEngine.Video;

namespace MornArbor
{
    public class PlayVideoProcess : ProcessBase
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private StateLink _nextStateLink;
        public override float Progress => _videoPlayer ? Mathf.Clamp01(_videoPlayer.frame / (float)_videoPlayer.frameCount) : 1f;

        public override void OnStateBegin()
        {
            _videoPlayer.Play();
        }
    }
}