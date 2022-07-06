namespace doc.api.Interface
{
    public interface IGenericHandler<T, R>
    {
        Task<R> execute(T request);
    }
}
