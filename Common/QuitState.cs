using Arbor;

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