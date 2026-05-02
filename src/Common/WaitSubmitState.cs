using MornLib;
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace MornLib
{
#if USE_MORNSTATE
	internal sealed class WaitSubmitState : MornStateBehaviour
#else
	internal sealed class WaitSubmitState : StateBehaviour
#endif
	{
		[SerializeField] private Selectable _target;
		[SerializeField] private StateLink _nextState;

		public override void OnStateBegin()
		{
			_target.OnSubmitAsObservable().Subscribe(_ => OnClick()).AddTo(CancellationTokenOnEnd);
		}

		private void OnClick()
		{
			Transition(_nextState);
		}
	}
}