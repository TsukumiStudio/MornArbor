#if USE_ARBOR
using System;
using Arbor;
namespace MornLib
{
    [Serializable]
    internal class QuitState : StateBehaviour
    {
        public override void OnStateBegin()
        {
            MornApp.Quit();
        }
    }
}
#endif
