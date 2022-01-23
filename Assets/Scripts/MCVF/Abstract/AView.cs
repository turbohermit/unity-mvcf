using UnityEngine;

namespace MVCF.Views
{
    public abstract class AView : MonoBehaviour, IControllerParameter
    {
        public virtual T Initialize<T>(bool p_startState = true) where T : AView
        {
            T view = Instantiate(this.gameObject).GetComponent<T>();
            DontDestroyOnLoad(view.gameObject);
            return view;
        }
    }
}
