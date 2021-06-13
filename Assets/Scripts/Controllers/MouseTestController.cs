using MVCF.Views;
using MVCF.Models;

namespace MVCF.Controllers
{
    public class MouseTestController : AController, IViewListener<LeftMouseView>, IViewListener<RightMouseView>
    {
        public MouseTestController(params IControllerParameter[] p_parameters) : base(p_parameters)
        {
        }

        public void OnUpdate(TestValueModel p_model)
        {
            throw new System.NotImplementedException();
        }

        public void Subscribe(LeftMouseView p_view) => p_view.OnInputReceived += ClickLeft;

        public void Subscribe(RightMouseView p_view) => p_view.OnInputReceived += ClickRight;


        public void Unsubscribe(LeftMouseView p_view) => p_view.OnInputReceived -= ClickLeft;

        public void Unsubscribe(RightMouseView p_view) => p_view.OnInputReceived -= ClickRight;

        private void ClickLeft()
        {
            JDebug.Log("Receive Left");
        }

        private void ClickRight()
        {
            JDebug.Log("Receive Right");
        }
    }
}
