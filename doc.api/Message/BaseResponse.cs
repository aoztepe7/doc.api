namespace doc.api.Message
{
    public class BaseResponse<T> : CommonResponse
    {
        public T? Data { get; set; }
    }
}
