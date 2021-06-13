using System;
using System.Reflection;
using System.Collections.Generic;
using MVCF.Models;

namespace MVCF.Controllers
{
    public abstract class AController : IControllerParameter
    {
        private static int m_initializationIndex;

        private List<AView> m_subscribedViews;

        protected bool m_isInitialized;

        protected AController(params IControllerParameter[] p_parameters)
        {
            foreach (IControllerParameter param in p_parameters)
            {
                switch (param)
                {
                    case AView view:
                        AddView(view);
                        break;
                        // case AModel model:
                        //     break;
                        // case AController controller:
                        //     break;
                }
            }

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
            m_isInitialized = false;

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
