using UnityEngine;
using MVCF.UI;

namespace MVCF.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class AUIView : AView
    {
        [SerializeField] private EHudElement m_hudKey;
        private CanvasGroup m_canvasGroup;

        public override T Initialize<T>(bool p_startState = true)
        {
            T view = Instantiate(this.gameObject, MasterCanvasView.GetHudElement(m_hudKey)).GetComponent<T>();
            AUIView uiView = view as AUIView;
            uiView?.ToggleVisible(p_startState);
            return view;
        }

        public void ToggleVisible(bool p_state)
        {
            if(m_canvasGroup == null)
                m_canvasGroup = this.GetComponent<CanvasGroup>();

            m_canvasGroup.alpha = p_state ? 1f : 0f;
            m_canvasGroup.interactable = p_state;
            m_canvasGroup.blocksRaycasts = p_state;
        }
    }
}
