using EmployeeManagement.Application.Models;
using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Core.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly ISalaryService _salaryService;

    public EmployeeController(IEmployeeService employeeService, ISalaryService salaryService)
    {
        _employeeService = employeeService;
        _salaryService = salaryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ViewEmployee>>> GetEmployees()
    {
        var employees = await _employeeService.GetEmployees();
        return Ok(employees);
    }
    
    [HttpGet("{name}")]
    public async Task<ActionResult<ViewEmployee>> GetEmployeeByName([FromRoute]string name)
    {
        var employee = await _employeeService.GetEmployeeByName(name);
        if (employee == null)
            return NotFound();
        return Ok(employee);
    }
    
    [HttpPost]
    public async Task<ActionResult<ViewEmployee>> CreateEmployee([FromBody]FormEmployee formEmployee)
    {
        var employee = await _employeeService.CreateEmployee(formEmployee);
        return Ok(employee);
    }
    
    [HttpPut("{name}")]
    public async Task<ActionResult<ViewEmployee>> UpdateEmployee([FromRoute]string name, [FromBody]FormEmployee formEmployee)
    {
        var employee = await _employeeService.UpdateEmployee(name, formEmployee);
        if (employee == null)
            return NotFound();
        return Ok(employee);
    }
    
    [HttpDelete("{name}")]
    public async Task<ActionResult<ViewEmployee>> DeleteEmployee([FromRoute]string name)
    {
        var employee = await _employeeService.DeleteEmployee(name);
        if (employee == null)
            return NotFound();
        return Ok(employee);
    }
    
    [HttpGet("{name}")]
    public async Task<ActionResult<decimal>> CalculateSalary([FromRoute]string name, DateOnly startDate, DateOnly endDate)
    {
        var salary = await _salaryService.CalculateSalary(name, startDate, endDate);
        if (salary == null)
            return NotFound();
        return Ok(salary);
    }
}