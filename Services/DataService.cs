using System.Text.Json;
using Employees.System.Models;
using Employees.System.Responses;
using Employees.System.Services.Interfaces;

namespace Employees.System.Services;

public class DataService : IDataService
{
    private readonly string _filePath = "EmployeesData.json";

    public async Task<SuccessResponse<List<EmployeeDataModel>>> GetAllAsync()
    {
        if (!File.Exists(_filePath))
            return new SuccessResponse<List<EmployeeDataModel>>(new List<EmployeeDataModel>());

        var json = await File.ReadAllTextAsync(_filePath);

        if (string.IsNullOrWhiteSpace(json))
            return new SuccessResponse<List<EmployeeDataModel>>(new List<EmployeeDataModel>());

        var res = JsonSerializer.Deserialize<List<EmployeeDataModel>>(json) ?? new List<EmployeeDataModel>();

        return new SuccessResponse<List<EmployeeDataModel>>(res);
    }

    public async Task<SuccessResponse<bool>> SaveAsync(EmployeeRequest request)
    {
        var employees = new List<EmployeeModel>();

        // read existing data
        if (File.Exists(_filePath))
        {
            var json = await File.ReadAllTextAsync(_filePath);

            if (!string.IsNullOrEmpty(json))
            {
                employees = JsonSerializer.Deserialize<List<EmployeeModel>>(json) ?? new List<EmployeeModel>();
            }
        }

        //validated dupliacte base on Name and Email. we can change it to diff props
        var exists = employees.Any(e =>
            e.Name.Equals(request.Name) &&
            e.Email.Equals(request.Email));

        if (exists)
        {
            return new SuccessResponse<bool>(false, "Employee already exists with same name and email");
        }

        // map to entity
        var employee = MapToModel(request);

        employees.Add(employee);

        // write back to file
        var newJson = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(_filePath, newJson);

        return new SuccessResponse<bool>(true);
    }

    private EmployeeModel MapToModel(EmployeeRequest request)
    {
        var model = new EmployeeModel
        {
            Name = request.Name,
            Email = request.Email,
            Department = request.Department,
            PhoneNumber = request.PhoneNumber,
            CreatedAt = DateTime.UtcNow
        };

        return model;
    }
}