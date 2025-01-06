using HRSystem.BLL.DTOs;
using HRSystem.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) {
            _employeeService= employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found");
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult>  Create([FromBody] EmployeeDTO employeeDto)
        {
            if (employeeDto == null) {
                return BadRequest("Employee Data is null.");
            }
            await _employeeService.AddEmployeeAsync(employeeDto);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(EmployeeDTO employeeDto,int id )
        {
            if (id != employeeDto.EmployeeId)
            {
                return BadRequest("Employee ID mismatch .");
            }
             await _employeeService.UpdateEmployeeAsync(employeeDto ,id);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var employee =await _employeeService.GetEmployeeByIdAsync(id);
            if (employee==null )
            {
                return BadRequest($"Employee with ID {id} not found.");
            }
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }


    }
}
