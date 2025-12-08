namespace Employees.System.Responses;

public class BaseResponse
{
    public int Code { get; protected set; } = 200;
    public string? Message { get; set; }
}
