using Employment.Core.DTOs;
using Employment.Core.Interfaces;

namespace Employment.Core.Services
{
    public class EmploymentService : IEmploymentService
    {
        public Task<Employer> AddEmployerAsync(Employer employer)
        {
            throw new NotImplementedException();
        }

        public Task<Role> AddRoleAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<Shift> AddShift(Shift shift)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEmployerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteShiftAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employer> GetEmployerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Employer>> GetAllEmployersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetRoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Role>> GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Shift> GetShiftAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Shift>> GetAllShiftsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employer> UpdateEmplyerAsync(Employer employer)
        {
            throw new NotImplementedException();
        }

        public Task<Role> UpdateRoleAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<Shift> UpdateShiftsAsync(Shift shift)
        {
            throw new NotImplementedException();
        }
    }
}
