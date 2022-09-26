using Employment.Core.DTOs;
using Employment.Core.Interfaces;
using Employment.Data.Contexts;

namespace Employment.Data.Repositories
{
    public class EmploymentRepository : IEmploymentRepository
    {
        private readonly EmploymentContext _employmentContext;

        public EmploymentRepository(EmploymentContext employmentContext)
        {
            _employmentContext = employmentContext;
        }

        #region Employer

        public async Task<Employer> AddEmployerAsync(Employer employer)
        {
            throw new NotImplementedException();
        }

        public async Task<Employer> GetEmployerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employer>> GetAllEmployersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Employer> UpdateEmployerAsync(Employer employer)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteEmployerAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Role

        public async Task<Role> AddRoleAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> GetRoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Shift

        public async Task<Shift> AddShiftAsync(Shift shift)
        {
            throw new NotImplementedException();
        }

        public async Task<Shift> GetShiftAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Shift>> GetAllShiftsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Shift> UpdateShiftAsync(Shift shift)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteShiftAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
