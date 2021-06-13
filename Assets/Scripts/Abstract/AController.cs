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
        private List<AModel> m_subscribedModels;

        protected bool m_isInitialized;

        #region CONSTRUCTOR
        protected AController(params IControllerParameter[] p_parameters)
        {
            foreach (IControllerParameter param in p_parameters)
            {
                switch (param)
                {
                    case AView view:
                        AddView(view);
                        break;
                    case AModel model:
                        AddModel(model);
                        break;
                    case AController controller:
                        break;
                }
            }

            Initialize();
        }
        #endregion

        #region PUBLIC
        public virtual void Initialize()
        {
            UnityEngine.Debug.LogFormat("{0} {1} initialized.", m_initializationIndex, this.GetType().ToString());
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
        #endregion

        #region PRIVATE
        //Automatic calls to call Subscribe implementation for each IViewListener type on derived class.
        protected void AddView(AView p_view)
        {
            Subscribe(p_view, typeof(IViewListener<>), "Subscribe");

            if (m_subscribedViews == null)
                m_subscribedViews = new List<AView>();

            m_subscribedViews.Add(p_view);
            OnViewAdded(p_view);
        }

        protected void RemoveView(AView p_view)
        {
            Subscribe(p_view, typeof(IViewListener<>), "Unsubscribe");
            m_subscribedViews.Remove(p_view);
            OnViewRemoved(p_view);

            if (m_subscribedViews.Count == 0)
                m_subscribedViews = null;
        }

        //Automatic calls to call Subscribe implementation for each IModelListener type on derived class.
        protected void AddModel(AModel p_model)
        {
            Subscribe(p_model, typeof(IModelListener<>), "Subscribe");

            if (m_subscribedModels == null)
                m_subscribedModels = new List<AModel>();

            m_subscribedModels.Add(p_model);
        }

        protected void RemoveModel(AModel p_model)
        {
            Subscribe(p_model, typeof(IModelListener<>), "Unsubscribe");
            m_subscribedModels.Remove(p_model);

            if (m_subscribedModels.Count == 0)
                m_subscribedModels = null;
        }

        private void Subscribe(IControllerParameter p_subscribable, Type p_targetInterface, string p_method)
        {
            Type controllerType = this.GetType();
            Type viewType = p_subscribable.GetType();
            Type interfaceType = p_targetInterface.MakeGenericType(viewType);
            if (interfaceType.IsAssignableFrom(controllerType))
            {
                MethodInfo subscribe = interfaceType.GetMethod(p_method); ;
                subscribe.Invoke(this, new object[] { p_subscribable });
            }
        }
        #endregion

        #region VIRTUAL
        ///<summary>Override for custom behaviour after a View is subscribed to.</summary>
        protected virtual void OnViewAdded(AView p_view)
        {

        }

        ///<summary>Override for custom behaviour after a View is unsubscribed from.</summary>
        protected virtual void OnViewRemoved(AView p_view)
        {

        }
        #endregion
    }
}
