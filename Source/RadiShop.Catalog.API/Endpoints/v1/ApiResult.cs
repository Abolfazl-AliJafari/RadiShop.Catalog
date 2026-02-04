namespace RadiShop.Catalog.API.Endpoints.v1;

public class ApiResult
{
    protected ApiResult(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }
    public bool IsSuccess { get; init; }

    public string Message { get; init; }
    
    public static ApiResult Success() => new(true, string.Empty);
    public static ApiResult Failure(string message) => new(false,message);
}

public sealed class ApiResult<T> : ApiResult
{
    private ApiResult(bool isSuccess, string message, T? data) : base(isSuccess, message)
    {
        Data = data;
    }
    public T? Data { get; set; }

    public static ApiResult<T> Success(T? data) => new(true, string.Empty, data);
    public static ApiResult<T> Failure(string message) => new(false,message , default);
} 