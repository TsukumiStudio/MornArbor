using Arbor;
using UnityEngine;

namespace MornLib
{
    internal class TransformDeltaState : StateBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _positionPerSec;
        [SerializeField] private Vector3 _rotationPerSec;
        [SerializeField] private Vector3 _scalePerSec;

        public override void OnStateUpdate()
        {
            var dt = Time.deltaTime;
            _target.localPosition += _positionPerSec * dt;
            _target.localEulerAngles += _rotationPerSec * dt;
            _target.localScale += _scalePerSec * dt;
        }
    }
}
