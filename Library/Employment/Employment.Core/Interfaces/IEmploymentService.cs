using Employment.Core.DTOs;

namespace Employment.Core.Interfaces
{
    public interface IEmploymentService
    {
        Task<Employer> AddEmployerAsync(Employer employer);

        Task<IEnumerable<Employer>> GetAllEmployersAsync();

        Task<Employer> GetEmployerAsync(int id);

        Task<Employer> UpdateEmplyerAsync(Employer employer);

        Task<bool> DeleteEmployerAsync(int id);



        Task<Role> AddRoleAsync(Role role);

        Task<IEnumerable<Role>> GetAllRolesAsync();

        Task<Role> GetRoleAsync(int id);

        Task<Role> UpdateRoleAsync(Role role);

        Task<bool> DeleteRoleAsync(int id);



        Task<Shift> AddShift(Shift shift);

        Task<IEnumerable<Shift>> GetAllShiftsAsync();

        Task<Shift> GetShiftAsync(int id);

        Task<Shift> UpdateShiftsAsync(Shift shift);

        Task<bool> DeleteShiftAsync(int id);
    }
}
