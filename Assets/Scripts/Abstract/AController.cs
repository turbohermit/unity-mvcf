using System;
using System.Reflection;
using System.Collections.Generic;

namespace MVCF.Controllers
{
    public abstract class AController
    {
        private static int m_initializationIndex;

        private List<AView> m_subscribedViews;

        protected bool m_isInitialized;

        protected AController(params AView[] p_views)
        {
            foreach (AView view in p_views)
                AddView(view);

            Initialize();
        }

        public virtual void Initialize()
        {
            JDebug.Log("{0} {1} initialized.", m_initializationIndex, this.GetType().ToString());
            m_initializationIndex++;
            m_isInitialized = true;
        }

        public virtual void Destroy()
        {
            for (int i = m_subscribedViews.Count - 1; i >= 0; i--)
            {
                RemoveView(m_subscribedViews[i]);
            }


        }

        protected virtual void AddView(AView p_view)
        {
            Type controllerType = this.GetType();
            Type viewType = p_view.GetType();
            Type interfaceType = typeof(IViewListener<>).MakeGenericType(viewType);
            if (interfaceType.IsAssignableFrom(controllerType))
            {
                MethodInfo subscribe = interfaceType.GetMethod("Subscribe"); ;
                subscribe.Invoke(this, new object[] { p_view });
            }

            if (m_subscribedViews == null)
                m_subscribedViews = new List<AView>();

            m_subscribedViews.Add(p_view);
        }

        protected virtual void RemoveView(AView p_view)
        {
            Type controllerType = this.GetType();
            Type viewType = p_view.GetType();
            Type interfaceType = typeof(IViewListener<>).MakeGenericType(viewType);
            if (interfaceType.IsAssignableFrom(controllerType))
            {
                MethodInfo subscribe = interfaceType.GetMethod("Unsubscribe"); ;
                subscribe.Invoke(this, new object[] { p_view });
            }

            m_subscribedViews.Remove(p_view);
        }
    }
}
