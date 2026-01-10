using Arbor;
using MornLib;

namespace MornArbor
{
    public class QuitState : StateBehaviour
    {
        public override void OnStateBegin()
        {
            MornApp.Quit();
        }
    }
}