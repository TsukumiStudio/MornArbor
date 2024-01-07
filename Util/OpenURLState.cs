using Arbor;
using MornWeb;
using UnityEngine;

namespace MornArbor
{
    public sealed class OpenURLState : StateBehaviour
    {
        [SerializeField] private string _url;

        public override void OnStateBegin()
        {
            MornWebUtil.Open(_url);
        }
    }
}