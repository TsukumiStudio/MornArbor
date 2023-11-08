using System;
using Arbor;
using MornUI;
using UnityEngine;

namespace MornArbor.States
{
    public class MornUIVisibilityState : StateBehaviour
    {
        [SerializeField] private MornUIVisibilityType _visibilityType;
        [SerializeField] private FlexibleField<MornUIVisibilityMonoBase> _visibility;

        public override void OnStateBegin()
        {
            switch (_visibilityType)
            {
                case MornUIVisibilityType.Hide:
                    _visibility.value.Hide();
                    break;
                case MornUIVisibilityType.HideImmediate:
                    _visibility.value.Hide(true);
                    break;
                case MornUIVisibilityType.Show:
                    _visibility.value.Show();
                    break;
                case MornUIVisibilityType.ShowImmediate:
                    _visibility.value.Show(true);
                    break;
                case MornUIVisibilityType.ShowFromHide:
                    _visibility.value.Hide(true);
                    _visibility.value.Show();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}