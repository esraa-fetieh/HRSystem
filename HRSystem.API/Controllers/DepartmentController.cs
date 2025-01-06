using HRSystem.BLL.DTOs;
using HRSystem.BLL.Repositories;
using HRSystem.BLL.Services;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetDepartmentsAsync();
            return Ok(departments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound($"Department with ID {id} not found");
            }
            return Ok(department);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentDTO departmentDto)
        {
            if (departmentDto == null)
            {
                return BadRequest("Department Data is null.");
            }
            await _departmentService.AddDepartmentAsync(departmentDto);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DepartmentDTO departmentDto, int id)
        {
            if (id != departmentDto.DepartmentId)
            {
                return BadRequest("Department ID mismatch .");
            }
            await _departmentService.UpdateDepartmentAsync(departmentDto, id);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return BadRequest($"Department with ID {id} not found.");
            }
            await _departmentService.DeleteDepartmentAsync(id);
            return Ok();
        }
    }
}
