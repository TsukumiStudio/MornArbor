using Arbor;
﻿using MornLib;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

namespace MornLib
{
    [Serializable]
    internal class WaitRandomTimeState : StateBehaviour
    {
        [SerializeField] private float _min;
        [SerializeField] private float _max;
        [SerializeField] private StateLink _next;
        private float _transitionTime;

        public override void OnStateBegin()
        {
            _transitionTime = Time.time + Random.Range(_min, _max);
        }

        public override void OnStateUpdate()
        {
            if (Time.time >= _transitionTime) Transition(_next);
        }
    }
}