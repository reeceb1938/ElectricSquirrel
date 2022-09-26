using Employment.Core.DTOs;
using Employment.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ElectricSquirrel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IEmploymentService _employmentService;

        public ShiftController(IEmploymentService employmentService)
        {
            _employmentService = employmentService;
        }

        [HttpPost]
        public async Task CreateShiftAsync(Shift shift)
        {
            await _employmentService.AddShiftAsync(shift);
        }

        [HttpGet("{id}")]
        public async Task<Shift> GetShiftAsync([FromRoute] int id)
        {
            return await _employmentService.GetShiftAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Shift>> GetAllShiftsAsync()
        {
            return await _employmentService.GetAllShiftsAsync();
        }

        [HttpPut("{id}")]
        public async Task<Shift> UpdateShift([FromForm] Shift shift)
        {
            return await _employmentService.UpdateShiftAsync(shift);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteShift([FromRoute] int id)
        {
            return await _employmentService.DeleteShiftAsync(id);
        }
    }
}
