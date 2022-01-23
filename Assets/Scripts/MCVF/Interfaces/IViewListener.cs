using MVCF.Views;

namespace MVCF.Controllers
{
    public interface IViewListener<T> where T : AView
    {
        void Subscribe(T p_view);
        void Unsubscribe(T p_view);
    }
}