using Employment.Core.DTOs;
using Employment.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ElectricSquirrel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IEmploymentService _employmentService;

        public RoleController(IEmploymentService employmentService)
        {
            _employmentService = employmentService;
        }

        [HttpPost]
        public async Task CreateRoleAsync(Role role)
        {
            await _employmentService.AddRoleAsync(role);
        }

        [HttpGet("{id}")]
        public async Task<Role> GetRoleAsync([FromRoute] int id)
        {
            return await _employmentService.GetRoleAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _employmentService.GetAllRolesAsync();
        }

        [HttpPut("{id}")]
        public async Task<Role> UpdateRole([FromForm] Role role)
        {
            return await _employmentService.UpdateRoleAsync(role);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteEmployer([FromRoute] int id)
        {
            return await _employmentService.DeleteEmployerAsync(id);
        }
    }
}
