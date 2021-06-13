namespace MVCF.Models
{
    public interface IModel<T> where T : AModel
    {
        System.Action<T> OnUpdate { get; }
    }
}
