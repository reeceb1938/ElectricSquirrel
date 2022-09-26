using Employment.Core.DTOs;
using Employment.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ElectricSquirrel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmploymentService _employmentService;

        public EmployerController(IEmploymentService employmentService)
        {
            _employmentService = employmentService;
        }

        [HttpPost]
        public async Task CreateEmployerAsync(Employer employer)
        {
            await _employmentService.AddEmployerAsync(employer);
        }

        [HttpGet("{id}")]
        public async Task<Employer> GetEmployerAsync([FromRoute] int id)
        {
            return await _employmentService.GetEmployerAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Employer>> GetAllEmployersAsync()
        {
            return await _employmentService.GetAllEmployersAsync();
        }

        [HttpPut("{id}")]
        public async Task<Employer> UpdateEmployer([FromForm] Employer employer)
        {
            return await _employmentService.UpdateEmplyerAsync(employer);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteEmployer([FromRoute] int id)
        {
            return await _employmentService.DeleteEmployerAsync(id);
        }
    }
}
