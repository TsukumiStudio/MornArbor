using System;
using System.Collections.Generic;
using System.Linq;
using Arbor;
using Cysharp.Threading.Tasks;
using MornAttribute;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MornInput
{
    [Serializable]
    internal class ButtonStateLinkSet
    {
        public Button Button;
        public StateLink StateLink;
    }

    public class ButtonState : StateBehaviour
    {
        [SerializeField] internal Transform Parent;
        [SerializeField] [ReadOnly] internal List<ButtonStateLinkSet> ButtonStateLinkSets;

        public override void OnStateBegin()
        {
            foreach (var buttonStateLinkSet in ButtonStateLinkSets)
                buttonStateLinkSet.Button.OnClickAsObservable().Subscribe(_ =>
                {
                    Transition(buttonStateLinkSet.StateLink);
                }).AddTo(CancellationTokenOnEnd);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(ButtonState))]
    public class ButtonStateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var buttonState = (ButtonState)target;
            if (GUILayout.Button("Gather"))
            {
                buttonState.ButtonStateLinkSets = buttonState.Parent.GetComponentsInChildren<Button>().Select(button =>
                {
                    var stateLinkSet = new ButtonStateLinkSet
                    {
                        Button = button, StateLink = new StateLink { name = button.name }
                    };
                    return stateLinkSet;
                }).ToList();
                buttonState.RebuildFields();
                EditorUtility.SetDirty(target);
            }
        }
    }
#endif
}