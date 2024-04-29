using System.Collections.Generic;
using UnityEngine;

namespace MornArbor
{
    public sealed class StateExitTrigger : MonoBehaviour
    {
        private readonly List<ISubStateCallback> callbackList = new();

        public void AddCallback(ISubStateCallback callback)
        {
            callbackList.Add(callback);
        }

        public void RemoveCallback(ISubStateCallback callback)
        {
            callbackList.Remove(callback);
        }

        public void Exit(string exitFlagName)
        {
            foreach (var callback in callbackList)
            {
                callback.Exit(exitFlagName);
            }
        }
    }
}