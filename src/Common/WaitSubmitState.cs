using MornLib;
using StateLink = MornLib.Connection;
using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace MornLib
{
#if USE_MORNSTATE
	[Serializable]
	internal sealed class WaitSubmitState : MornStateBehaviour
#else
	[Serializable]
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