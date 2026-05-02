#if USE_VIDEO
#if USE_MORNSTATE
using MornLib;
#else
using Arbor;
#endif
using UnityEngine;
using UnityEngine.Video;

namespace MornLib
{
#if USE_MORNSTATE
    internal class LoadVideoState : MornStateBehaviour
#else
    internal class LoadVideoState : StateBehaviour
#endif
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
#endif