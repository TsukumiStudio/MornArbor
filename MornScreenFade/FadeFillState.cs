using Arbor;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace MornScreenFade
{
    public class FadeFillState : StateBehaviour
    {
        [SerializeField] private StateLink _next;
        private UniTask _fadeTask;
        [Inject] private IMornScreenFade _transition;

        public override void OnStateBegin()
        {
            _fadeTask = _transition.FadeFillAsync(CancellationTokenOnEnd);
        }

        public override void OnStateUpdate()
        {
            if (_fadeTask.Status != UniTaskStatus.Pending) Transition(_next);
        }
    }
}