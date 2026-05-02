#if USE_MORNSTATE
using MornLib;
#else
using Arbor;
#endif
namespace MornLib
{
#if USE_MORNSTATE
    internal class QuitState : MornStateBehaviour
#else
    internal class QuitState : StateBehaviour
#endif
    {
        public override void OnStateBegin()
        {
            MornApp.Quit();
        }
    }
}