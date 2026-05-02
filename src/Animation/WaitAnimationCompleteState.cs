#if USE_MORNSTATE
using MornLib;
using StateLink = MornLib.Connection;
using System;
#else
using Arbor;
#endif
using UnityEngine;

namespace MornLib
{
    /// <summary>現在のアニメーションが終了するまで待機するState</summary>
#if USE_MORNSTATE
    [Serializable]
    internal sealed class WaitAnimationCompleteState : MornStateBehaviour
#else
    [Serializable]
    internal sealed class WaitAnimationCompleteState : StateBehaviour
#endif
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private int _layer;
        [SerializeField] private StateLink _onComplete;

        public override void OnStateUpdate()
        {
            // 遷移中は待機
            if (_animator.IsInTransition(_layer))
            {
                return;
            }

            var stateInfo = _animator.GetCurrentAnimatorStateInfo(_layer);
            // normalizedTimeが1以上 かつ ループアニメーションでない場合は終了とみなす
            if (stateInfo.normalizedTime >= 1.0f && !stateInfo.loop)
            {
                Transition(_onComplete);
            }
        }
    }
}