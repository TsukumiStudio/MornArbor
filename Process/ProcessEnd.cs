using System.Collections.Generic;
using System.Linq;
using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class ProcessEnd : StateBehaviour
    {
        [SerializeField] private StateLink _nextState;
        private readonly List<ProcessBase> _processList = new();

        public override void OnStateBegin()
        {
            _processList.Clear();
            foreach (var behaviour in GetBehaviours<StateBehaviour>())
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