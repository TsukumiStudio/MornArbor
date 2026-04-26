using System;
using Arbor;
using UnityEngine;

namespace MornLib
{
    internal class WeightTransitionState : StateBehaviour
    {
        [Serializable]
        private struct Entry
        {
            public StateLink Next;
            public float Weight;
        }

        [SerializeField] private Entry[] _entries;

        protected override void OnValidate()
        {
            base.OnValidate();
            if (_entries == null)
            {
                return;
            }

            var total = 0f;
            for (var i = 0; i < _entries.Length; i++)
            {
                if (_entries[i].Weight > 0)
                {
                    total += _entries[i].Weight;
                }
            }

            for (var i = 0; i < _entries.Length; i++)
            {
                var link = _entries[i].Next;
                if (link == null)
                {
                    continue;
                }

                var weight = _entries[i].Weight;
                var percent = total > 0 && weight > 0 ? weight / total * 100f : 0f;
                link.name = $"Weight {weight:0.##} ({percent:0.#}%)";
            }
        }

        public override void OnStateBegin()
        {
            if (_entries == null || _entries.Length == 0)
            {
                return;
            }

            var total = 0f;
            for (var i = 0; i < _entries.Length; i++)
            {
                var weight = _entries[i].Weight;
                if (weight > 0)
                {
                    total += weight;
                }
            }

            if (total <= 0)
            {
                return;
            }

            var r = UnityEngine.Random.value * total;
            var acc = 0f;
            for (var i = 0; i < _entries.Length; i++)
            {
                var weight = _entries[i].Weight;
                if (weight <= 0)
                {
                    continue;
                }

                acc += weight;
                if (r <= acc)
                {
                    Transition(_entries[i].Next);
                    return;
                }
            }

            Transition(_entries[_entries.Length - 1].Next);
        }
    }
}
