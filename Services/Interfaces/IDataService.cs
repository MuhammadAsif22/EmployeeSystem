using Employees.System.Models;
using Employees.System.Responses;

namespace Employees.System.Services.Interfaces;

public interface IDataService
{
    Task<SuccessResponse<List<EmployeeDataModel>>> GetAllAsync();
    Task<SuccessResponse<bool>> SaveAsync(EmployeeRequest request);
}
