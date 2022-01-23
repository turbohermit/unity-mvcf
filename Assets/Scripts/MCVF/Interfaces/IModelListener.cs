namespace MVCF.Controllers
{
    public interface IModelListener<T> where T : Models.AModel
    {
        void Subscribe(T p_model);
        void Unsubscribe(T p_model);
    }
}
