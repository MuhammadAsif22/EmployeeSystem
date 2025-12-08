namespace Employees.System.Responses;

public class ErrorResponse : BaseResponse
{
    public ErrorResponse(string? message = null, int code = 400)
    {
        Code = code;
        Message = message ?? "An error occurred";
    }
}