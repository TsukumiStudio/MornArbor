using MornLib;

namespace MornLib
{
    internal class QuitState : StateBehaviour
    {
        public override void OnStateBegin()
        {
            MornApp.Quit();
        }
    }
}