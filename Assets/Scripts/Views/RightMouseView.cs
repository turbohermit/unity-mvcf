using UnityEngine;
using System;

namespace MVCF.Views
{
    public class RightMouseView : AView
    {
        public Action OnInputReceived;

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                OnInputReceived?.Invoke();
            }
        }
    }
}
