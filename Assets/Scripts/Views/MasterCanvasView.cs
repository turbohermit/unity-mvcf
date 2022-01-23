using UnityEngine;
using MVCF.UI;

namespace MVCF.Views
{
    public class MasterCanvasView : AView
    {
        [SerializeField] private HudElementReference[] m_hudReferences;
        private RectTransform m_rectTransform;

        private static MasterCanvasView m_instance;

        private void Awake()
        {
            m_instance = this;
            m_rectTransform = GetComponent<RectTransform>();
        }

        public static RectTransform GetHudElement(EHudElement p_key)
        {
            if(m_instance == null)
            {
                Debug.LogError($"MasterCanvas is not initialized. Transform for {p_key} could not be returned.");
                return null;
            }

            //Spawn directly in canvas if no hud key is supplied.
            if(p_key == EHudElement.NONE)
                return m_instance.m_rectTransform;

            foreach(var hudRef in m_instance.m_hudReferences)
            {
                if(hudRef.Key != p_key)
                continue;

                if(hudRef.Transform != null)
                    return hudRef.Transform;
                else
                {
                    Debug.LogError($"HUD reference in {hudRef.Key} is not assigned in MasterCanvas.");
                    return m_instance.m_rectTransform;
                }
            }

            Debug.LogError($"HUD key {p_key} is not found in MasterCanvas HUD references.");
            return m_instance.m_rectTransform;   
        }
    }
}