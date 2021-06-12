using UnityEngine;
using System;

namespace MVCF.Views
{
    public class LeftMouseView : AView
    {
        public Action OnInputReceived;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                JDebug.Log("Send left");
                OnInputReceived?.Invoke();
            }
        }
    }
}