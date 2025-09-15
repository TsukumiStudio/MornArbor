using Arbor;
using MornUtil;

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