using System;

namespace MVCF.Controllers
{
    public abstract class AController
    {
        private static int m_initializationIndex;

        public virtual void Initialize()
        {
            JDebug.Log("{0} {1} initialized.", m_initializationIndex, this.GetType().ToString());
            m_initializationIndex++;
        }

        protected AController(params AView[] p_views)
        {
            Type controllerType = this.GetType();
            foreach (AView view in p_views)
            {
                AddView(view);
                // System.Type viewType = view.GetType();
                // Type t = typeof(IViewListener<>).MakeGenericType(viewType);
                // if (t.IsAssignableFrom(controllerType))
                // {
                //     How to call Subscribe on IViewListener only using the view type variable?
                // }
            }

            Initialize();
        }

        protected virtual void AddView(AView p_view)
        {

        }
    }
}
