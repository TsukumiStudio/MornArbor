using System;
using Arbor;
using MornUI;
using UniRx;
using UnityEngine;

namespace MornArbor
{
    public class MornUIButtonTransitionState : StateBehaviour
    {
        [SerializeField] private FlexibleField<MornUIButtonMono> _button;
        [SerializeField] private StateLink _next;
        private IDisposable _disposable;

        public override void OnStateBegin()
        {
            _disposable = _button.value.OnSubmitAsObservable.Subscribe(_ => Transition(_next));
        }

        public override void OnStateEnd()
        {
            _disposable?.Dispose();
        }
    }
}