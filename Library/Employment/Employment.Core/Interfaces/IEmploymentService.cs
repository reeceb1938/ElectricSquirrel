using Employment.Core.DTOs;

namespace Employment.Core.Interfaces
{
    public interface IEmploymentService
    {
        Task<Employer> AddEmployerAsync(Employer employer);

        Task<IList<Employer>> GetAllEmployersAsync();

        Task<Employer> GetEmployerAsync(int id);

        Task<Employer> UpdateEmplyerAsync(Employer employer);

        Task<bool> DeleteEmployerAsync(int id);



        Task<Role> AddRoleAsync(Role role);

        Task<IList<Role>> GetAllRolesAsync();

        Task<Role> GetRoleAsync(int id);

        Task<Role> UpdateRoleAsync(Role role);

        Task<bool> DeleteRoleAsync(int id);



        Task<Shift> AddShift(Shift shift);

        Task<IList<Shift>> GetAllShiftsAsync();

        Task<Shift> GetShiftAsync();

        Task<Shift> UpdateShiftsAsync(Shift shift);

        Task<bool> DeleteShiftAsync(int id);
    }
}
