using Arbor;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MornLib
{
    /// <summary>
    /// 指定UIBehaviourのポインターイベントごとに遷移するState。
    /// 不要な遷移先は未設定のままでよい。
    /// </summary>
    internal sealed class OnPointerEventState : StateBehaviour
    {
        [SerializeField] private UIBehaviour _target;
        [SerializeField] private StateLink _onPointerEnter;
        [SerializeField] private StateLink _onPointerExit;
        [SerializeField] private StateLink _onPointerDown;
        [SerializeField] private StateLink _onPointerUp;
        [SerializeField] private StateLink _onPointerClick;

        private CompositeDisposable _disposables;

        public override void OnStateBegin()
        {
            _disposables = new CompositeDisposable();
            _target.OnPointerEnterAsObservable()
                .Subscribe(_ => Transition(_onPointerEnter))
                .AddTo(_disposables);
            _target.OnPointerExitAsObservable()
                .Subscribe(_ => Transition(_onPointerExit))
                .AddTo(_disposables);
            _target.OnPointerDownAsObservable()
                .Subscribe(_ => Transition(_onPointerDown))
                .AddTo(_disposables);
            _target.OnPointerUpAsObservable()
                .Subscribe(_ => Transition(_onPointerUp))
                .AddTo(_disposables);
            _target.OnPointerClickAsObservable()
                .Subscribe(_ => Transition(_onPointerClick))
                .AddTo(_disposables);
        }

        public override void OnStateEnd()
        {
            _disposables?.Dispose();
            _disposables = null;
        }
    }
}
