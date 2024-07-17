using System.Collections.Generic;
using System.Linq;
using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class ProcessIfAll : StateBehaviour
    {
        [SerializeField] private StateLink _nextState;
        private readonly List<IProcessState> _processList = new();

        public override void OnStateBegin()
        {
            _processList.Clear();
            foreach (var behaviour in GetBehaviours<StateBehaviour>())
            {
                if (behaviour is IProcessState process)
                {
                    _processList.Add(process);
                }
            }
        }

        public override void OnStateUpdate()
        {
            if (_processList.All(x => !x.IsActive))
            {
                Transition(_nextState);
            }
        }
    }
}