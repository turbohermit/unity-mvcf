using UnityEngine;

namespace MVCF.Models
{
    public abstract class AModel : ScriptableObject, IControllerParameter
    {
        public virtual T Initialize<T>() where T : AModel
        {
            return Instantiate(this) as T;
        }
    }
}
