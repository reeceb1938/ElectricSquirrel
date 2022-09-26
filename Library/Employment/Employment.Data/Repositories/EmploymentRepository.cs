using Employment.Core.DTOs;
using Employment.Core.Enums;
using Employment.Core.Interfaces;
using Employment.Data.Contexts;
using Employment.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

        public async Task<Core.DTOs.Employer> AddEmployerAsync(Core.DTOs.Employer employer)
        {
            var newEmployer = new Models.Employer
            {
                Name = employer.Name
            };

            await _employmentContext.AddAsync(newEmployer);
            await _employmentContext.SaveChangesAsync();

            return await GetEmployerAsync(newEmployer.Id);
        }

        public async Task<Core.DTOs.Employer> GetEmployerAsync(int id)
        {
            return (await _employmentContext.Employers.Where(x => x.Id == id).FirstAsync()).ToDto();
        }

        public async Task<IEnumerable<Core.DTOs.Employer>> GetAllEmployersAsync()
        {
            var result = new List<Core.DTOs.Employer>();
            (await _employmentContext.Employers.ToListAsync()).ForEach(x => result.Add(x.ToDto()));
            return result;
        }

        public async Task<Core.DTOs.Employer> UpdateEmployerAsync(Core.DTOs.Employer employer)
        {
            var existingEmployer = await _employmentContext.Employers.Where(x => x.Id == employer.Id).FirstAsync();

            existingEmployer.Name = employer.Name;

            await _employmentContext.SaveChangesAsync();

            return await GetEmployerAsync(employer.Id);
        }

        public async Task<bool> DeleteEmployerAsync(int id)
        {
            var employer = await _employmentContext.Employers.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (employer is null)
            {
                return true;
            }

            _employmentContext.Employers.Remove(employer);

            return true;
        }

        #endregion

        #region Role

        public async Task<Core.DTOs.Role> AddRoleAsync(Core.DTOs.Role role)
        {
            var newRole = new Models.Role
            {
                Name = role.Name,
                Employer = await _employmentContext.Employers.Where(x => x.Id == role.Employer.Id).FirstAsync(),
                PayRate = role.PayRate,
                PayPeriod = role.PayPeriod,
                PayType = role.PayType
            };

            await _employmentContext.AddAsync(newRole);
            await _employmentContext.SaveChangesAsync();

            return await GetRoleAsync(newRole.Id);
        }

        public async Task<Core.DTOs.Role> GetRoleAsync(int id)
        {
            return (await _employmentContext.Roles.Where(x => x.Id == id).FirstAsync()).ToDto();
        }

        public async Task<IEnumerable<Core.DTOs.Role>> GetAllRolesAsync()
        {
            var result = new List<Core.DTOs.Role>();
            (await _employmentContext.Roles.ToListAsync()).ForEach(x => result.Add(x.ToDto()));
            return result;
        }

        public async Task<Core.DTOs.Role> UpdateRoleAsync(Core.DTOs.Role role)
        {
            var existingRole = await _employmentContext.Roles.Where(x => x.Id == role.Id).FirstAsync();

            existingRole.Name = existingRole.Name;
            existingRole.Employer = await _employmentContext.Employers.Where(x => x.Id == role.Id).FirstAsync();
            existingRole.PayRate = role.PayRate;
            existingRole.PayPeriod = role.PayPeriod;
            existingRole.PayType = role.PayType;

            await _employmentContext.SaveChangesAsync();

            return await GetRoleAsync(role.Id);
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _employmentContext.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (role is null)
            {
                return true;
            }

            _employmentContext.Roles.Remove(role);

            return true;
        }

        #endregion

        #region Shift

        public async Task<Core.DTOs.Shift> AddShiftAsync(Core.DTOs.Shift shift)
        {
            var employer = await _employmentContext.Employers.Where(x => x.Id == shift.Employer.Id).FirstAsync();
            var role = await _employmentContext.Roles.Where(x => x.Id == shift.Role.Id).FirstAsync();

            var newShift = new Models.Shift
            {
                Employer = employer,
                Role = role,
                RoleName = role.Name,
                PayRate = role.PayRate,
                PayPeriod = role.PayPeriod,
                PayType = role.PayType,
                StartDateTime = shift.StartDateTime,
                EndDateTime = shift.EndDateTime,
                BreakInMinutes = shift.BreakInMinutes,
                RecordedStartDateTime = shift.RecordedStartDateTime,
                RecordedEndDateTime = shift.RecordedEndDateTime,
                RecordedBreakInMinutes = shift.RecordedBreakInMinutes,
                IsProspective = shift.IsProspective
            };

            await _employmentContext.AddAsync(newShift);
            await _employmentContext.SaveChangesAsync();

            return await GetShiftAsync(newShift.Id);
        }

        public async Task<Core.DTOs.Shift> GetShiftAsync(int id)
        {
            return (await _employmentContext.Shifts.Where(x => x.Id == id).FirstAsync()).ToDto();
        }

        public async Task<IEnumerable<Core.DTOs.Shift>> GetAllShiftsAsync()
        {
            var result = new List<Core.DTOs.Shift>();
            (await _employmentContext.Shifts.ToListAsync()).ForEach(x => result.Add(x.ToDto()));
            return result;
        }

        public async Task<Core.DTOs.Shift> UpdateShiftAsync(Core.DTOs.Shift shift)
        {
            var existingShift = await _employmentContext.Shifts.Where(x => x.Id == shift.Id).FirstAsync();
            var employer = await _employmentContext.Employers.Where(x => x.Id == shift.Employer.Id).FirstAsync();
            var role = await _employmentContext.Roles.Where(x => x.Id == shift.Role.Id).FirstAsync();

            existingShift.Employer = employer;
            existingShift.Role = role;
            existingShift.RoleName = shift.Role.Name;
            existingShift.PayRate = shift.Role.PayRate;
            existingShift.PayPeriod = shift.Role.PayPeriod;
            existingShift.PayType = shift.Role.PayType;
            existingShift.StartDateTime = shift.StartDateTime;
            existingShift.EndDateTime = shift.EndDateTime;
            existingShift.BreakInMinutes = shift.BreakInMinutes;
            existingShift.RecordedStartDateTime = shift.RecordedStartDateTime;
            existingShift.RecordedEndDateTime = shift.RecordedEndDateTime;
            existingShift.RecordedBreakInMinutes = shift.RecordedBreakInMinutes;
            existingShift.IsProspective = shift.IsProspective;

            await _employmentContext.SaveChangesAsync();

            return await GetShiftAsync(shift.Id);
        }

        public async Task<bool> DeleteShiftAsync(int id)
        {
            var shift = await _employmentContext.Shifts.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (shift is null)
            {
                return true;
            }

            _employmentContext.Shifts.Remove(shift);

            return true;
        }

        #endregion
    }
}
