using MVCF.Views;

namespace MVCF.Controllers
{
    public class MouseTestController : AController, IViewListener<LeftMouseView>, IViewListener<RightMouseView>
    {
        public MouseTestController(params AView[] p_views) : base(p_views) { }

        protected override void AddView(AView p_view)
        {
            switch (p_view)
            {
                case LeftMouseView view:
                    Subscribe(view);
                    break;
                case RightMouseView view:
                    Subscribe(view);
                    break;
            }
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
