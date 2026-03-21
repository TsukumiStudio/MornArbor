using System;
using Arbor;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MornLib
{
    internal class WaitPointerEventState : StateBehaviour
    {
        [SerializeField] private UIBehaviour _target;
        [SerializeField] private PointerEventType _pointerEventType;
        [SerializeField] private StateLink _nextState;

        private CompositeDisposable _disposables;

        public override void OnStateBegin()
        {
            _disposables = new CompositeDisposable();
            var observable = _pointerEventType switch
            {
                PointerEventType.PointerDown  => _target.OnPointerDownAsObservable(),
                PointerEventType.PointerUp    => _target.OnPointerUpAsObservable(),
                PointerEventType.PointerEnter => _target.OnPointerEnterAsObservable(),
                PointerEventType.PointerExit  => _target.OnPointerExitAsObservable(),
                PointerEventType.PointerClick => _target.OnPointerClickAsObservable(),
                _                             => throw new ArgumentOutOfRangeException()
            };
            observable.Subscribe(_ => Transition(_nextState)).AddTo(_disposables);
        }

        public override void OnStateEnd()
        {
            _disposables?.Dispose();
            _disposables = null;
        }

        private enum PointerEventType
        {
            PointerDown,
            PointerUp,
            PointerEnter,
            PointerExit,
            PointerClick
        }
    }
}
