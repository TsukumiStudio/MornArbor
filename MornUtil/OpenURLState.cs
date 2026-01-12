#if USE_MORN_UTIL
using Arbor;
using UnityEngine;

namespace MornLib
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
#endif