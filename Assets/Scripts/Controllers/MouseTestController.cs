using MVCF.Views;
using MVCF.Models;

namespace MVCF.Controllers
{
    public class MouseTestController : AController, IViewListener<LeftMouseView>, IViewListener<RightMouseView>, IModelListener<TestValueModel>
    {
        private TestValueModel m_testValue;

        public MouseTestController(params IControllerParameter[] p_parameters) : base(p_parameters) { }

        public void Subscribe(LeftMouseView p_view) => p_view.OnInputReceived += ClickLeft;

        public void Subscribe(RightMouseView p_view) => p_view.OnInputReceived += ClickRight;

        public void Subscribe(TestValueModel p_model)
        {
            m_testValue = p_model;
            p_model.OnUpdate += OnModelUpdated;
        }

        public void Unsubscribe(LeftMouseView p_view) => p_view.OnInputReceived -= ClickLeft;

        public void Unsubscribe(RightMouseView p_view) => p_view.OnInputReceived -= ClickRight;

        public void Unsubscribe(TestValueModel p_model)
        {
            m_testValue = null;
            p_model.OnUpdate -= OnModelUpdated;
        }

        private void ClickLeft()
        {
            UnityEngine.Debug.LogFormat("Receive Left");
            m_testValue.AddValue();
        }

        private void ClickRight()
        {
            UnityEngine.Debug.LogFormat("Receive Right");
        }

        private void OnModelUpdated(TestValueModel p_model)
        {
            UnityEngine.Debug.LogFormat("Test value: {0}", p_model.value);
        }
    }
}
