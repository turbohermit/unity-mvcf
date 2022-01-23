namespace MVCF.Controllers
{
    public interface IControllerListener<T> where T : AController
    {
        void Subscribe(T p_controller);
        void Unsubscribe(T p_controller);
    }
}
