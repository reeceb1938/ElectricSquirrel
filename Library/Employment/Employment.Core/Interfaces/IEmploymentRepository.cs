using Employment.Core.DTOs;

namespace Employment.Core.Interfaces
{
    public interface IEmploymentRepository
    {
        Task<Employer> AddEmployerAsync(Employer employer);
        Task<Employer> GetEmployerAsync(int id);
        Task<IEnumerable<Employer>> GetAllEmployersAsync();
        Task<Employer> UpdateEmployerAsync(Employer employer);
        Task<bool> DeleteEmployerAsync(int id);

        Task<Role> AddRoleAsync(Role role);
        Task<Role> GetRoleAsync(int id);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> UpdateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(int id);

        Task<Shift> AddShiftAsync(Shift shift);
        Task<Shift> GetShiftAsync(int id);
        Task<IEnumerable<Shift>> GetAllShiftsAsync();
        Task<Shift> UpdateShiftAsync(Shift shift);
        Task<bool> DeleteShiftAsync(int id);
    }
}
