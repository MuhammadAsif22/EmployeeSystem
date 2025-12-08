using Employees.System.Models;
using Employees.System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employees.System.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IDataService _dataService;

    public EmployeesController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRecords()
    {
        var res = await _dataService.GetAllAsync();

        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> SaveRecordAsync([FromBody] EmployeeRequest request)
    {
        var res = await _dataService.SaveAsync(request);

        return Ok(res);
    }
}
