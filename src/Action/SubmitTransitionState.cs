#if USE_MORNSTATE
using MornLib;
#else
using Arbor;
#endif
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace MornLib
{
#if USE_MORNSTATE
    internal class SubmitTransitionState : MornStateBehaviour
#else
    internal class SubmitTransitionState : StateBehaviour
#endif
    {
        [SerializeField] private Selectable _target;
        [SerializeField] private StateLink _onSubmit;

        public override void OnStateBegin()
        {
            _target.OnSubmitAsObservable()
                .Subscribe(_ => Transition(_onSubmit))
                .AddTo(CancellationTokenOnEnd);
        }
    }
}
