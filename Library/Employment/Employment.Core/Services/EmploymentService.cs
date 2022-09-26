using Employment.Core.DTOs;
using Employment.Core.Interfaces;

namespace Employment.Core.Services
{
    public class EmploymentService : IEmploymentService
    {
        private readonly IEmploymentRepository _employmentRepository;

        public EmploymentService(IEmploymentRepository employmentRepository)
        {
            _employmentRepository = employmentRepository;
        }

        public async Task<Employer> AddEmployerAsync(Employer employer)
        {
            return await _employmentRepository.AddEmployerAsync(employer);
        }

        public async Task<Role> AddRoleAsync(Role role)
        {
            return await _employmentRepository.AddRoleAsync(role);
        }

        public async Task<Shift> AddShiftAsync(Shift shift)
        {
            return await _employmentRepository.AddShiftAsync(shift);
        }

        public async Task<bool> DeleteEmployerAsync(int id)
        {
            return await _employmentRepository.DeleteEmployerAsync(id);
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            return await _employmentRepository.DeleteRoleAsync(id);
        }

        public async Task<bool> DeleteShiftAsync(int id)
        {
            return await _employmentRepository.DeleteShiftAsync(id);
        }

        public async Task<Employer> GetEmployerAsync(int id)
        {
            return await _employmentRepository.GetEmployerAsync(id);
        }

        public async Task<IEnumerable<Employer>> GetAllEmployersAsync()
        {
            return await _employmentRepository.GetAllEmployersAsync();
        }

        public async Task<Role> GetRoleAsync(int id)
        {
            return await _employmentRepository.GetRoleAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _employmentRepository.GetAllRolesAsync();
        }

        public async Task<Shift> GetShiftAsync(int id)
        {
            return await _employmentRepository.GetShiftAsync(id);
        }

        public async Task<IEnumerable<Shift>> GetAllShiftsAsync()
        {
            return await _employmentRepository.GetAllShiftsAsync();
        }

        public async Task<Employer> UpdateEmplyerAsync(Employer employer)
        {
            return await _employmentRepository.UpdateEmployerAsync(employer);
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            return await _employmentRepository.UpdateRoleAsync(role);
        }

        public async Task<Shift> UpdateShiftAsync(Shift shift)
        {
            return await _employmentRepository.UpdateShiftAsync(shift);
        }
    }
}
