using System.Collections.Generic;
using System.Linq;
using System;
#if USE_MORNSTATE
using MornLib;
using StateLink = MornLib.Connection;
#else
using Arbor;
#endif
using UnityEngine;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal class ProcessEnd : MornStateBehaviour
#else
    [Serializable]
    internal class ProcessEnd : StateBehaviour
#endif
    {
        [SerializeField] private StateLink _nextState;
        private readonly List<ProcessBase> _processList = new();

        public override void OnStateBegin()
        {
            _processList.Clear();
#if USE_MORNSTATE
            foreach (var behaviour in GetBehaviours<MornStateBehaviour>())
#else
            foreach (var behaviour in GetBehaviours<StateBehaviour>())
#endif
            {
                if (behaviour is ProcessBase process)
                {
                    _processList.Add(process);
                }
            }
        }

        public override void OnStateUpdate()
        {
            if (_processList.All(x => x.Progress >= 1))
            {
                Transition(_nextState);
            }
        }
    }
}