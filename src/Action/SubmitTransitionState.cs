#if USE_MORNSTATE
using MornLib;
using StateLink = MornLib.Connection;
using System;
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
    [Serializable]
    internal class SubmitTransitionState : MornStateBehaviour
#else
    [Serializable]
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
