using System.Collections.Generic;
using Arbor;
using MornTween;
using UnityEngine;

namespace MornArbor.Tween
{
    public class MornTweenProcess : ProcessBase
    {
        [SerializeField] private List<MornTweenBase> _tweenList;
        [SerializeField] private StateLink _nextState;
        private float _progress;
        public override float Progress => _progress;

        public override void OnStateBegin()
        {
            foreach (var tween in _tweenList)
            {
                tween.TweenStart();
            }

            _progress = 0f;
        }

        public override void OnStateUpdate()
        {
            var progressSum = 0f;
            foreach (var tween in _tweenList)
            {
                progressSum += tween.Progress;
            }

            _progress = Mathf.Clamp01(progressSum / _tweenList.Count);
            if (_progress >= 1f)
            {
                Transition(_nextState);
            }
        }
    }
}