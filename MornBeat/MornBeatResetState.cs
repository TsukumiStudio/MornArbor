using Arbor;
using VContainer;

namespace MornBeat
{
    public class MornBeatResetState : StateBehaviour
    {
        [Inject] private MornBeatControllerMono _beatController;

        public override void OnStateBegin()
        {
            _beatController.ResetBeat();
        }
    }
}