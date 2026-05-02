#if USE_MORNSTATE
using MornLib;
#else
using Arbor;
#endif
using UnityEngine;

namespace MornLib
{
#if USE_MORNSTATE
    internal class TransformDeltaState : MornStateBehaviour
#else
    internal class TransformDeltaState : StateBehaviour
#endif
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _positionPerSec;
        [SerializeField] private Vector3 _rotationPerSec;
        [SerializeField] private Vector3 _scalePerSec;
        [SerializeField] private bool _useUnscaledTime;

        public override void OnStateUpdate()
        {
            var dt = _useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            _target.localPosition += _positionPerSec * dt;
            _target.localEulerAngles += _rotationPerSec * dt;
            _target.localScale += _scalePerSec * dt;
        }
    }
}
