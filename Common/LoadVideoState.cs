using Arbor;
using UnityEngine;
using UnityEngine.Video;

namespace MornArbor
{
    public class LoadVideoState : StateBehaviour
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private VideoClip _videoClip;
        [SerializeField] private bool _autoPlay = true;
        [SerializeField] private StateLink _onPlay;

        public override void OnStateBegin()
        {
            _videoPlayer.clip = _videoClip;
            _videoPlayer.Prepare();
            _videoPlayer.prepareCompleted += OnVideoPrepared;
        }

        private void OnVideoPrepared(VideoPlayer source)
        {
            if (_autoPlay)
            {
                source.Play();
            }
        }

        public override void OnStateUpdate()
        {
            if (_videoPlayer.frameCount > 0)
            {
                Transition(_onPlay);
            }
        }

        public override void OnStateEnd()
        {
            _videoPlayer.prepareCompleted -= OnVideoPrepared;
        }
    }
}