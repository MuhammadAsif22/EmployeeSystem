namespace Employees.System.Responses;

public class SuccessResponse<T> : BaseResponse
{
    public T? Result { get; set; }

    public SuccessResponse()
    {
        Code = 200;
    }

    public SuccessResponse(T? result, string? message = null)
    {
        Code = 200;
        Result = result;
        Message = message;
    }
}
