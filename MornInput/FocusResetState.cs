using Arbor;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace MornInput
{
    public class FocusResetState : StateBehaviour
    {
        [SerializeField] private GameObject _focusObject;
        [Inject] private IMornInput _inputController;

        public override void OnStateBegin()
        {
            _inputController.OnSchemeChanged.Subscribe(pair =>
            {
                var (prev, next) = pair;
                if (next == "Mouse") EventSystem.current.SetSelectedGameObject(null);
                else if (prev == "Mouse") EventSystem.current.SetSelectedGameObject(_focusObject);
            }).AddTo(CancellationTokenOnEnd);
        }
    }
}