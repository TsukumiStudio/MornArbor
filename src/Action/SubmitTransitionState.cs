using System;
using Arbor;
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace MornLib
{
    [Serializable]
    internal class SubmitTransitionState : StateBehaviour
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
