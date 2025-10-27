using Microsoft.EntityFrameworkCore;
using STBEmployeeEntry.Data;
using STBEmployeeEntry.Interface;
using STBEmployeeEntry.Model;
using static STBEmployeeEntry.Service.STBEmployeeService;

namespace STBEmployeeEntry.Service
{
    public class STBEmployeeService : ISTBEmployeeEntry
    {
        private readonly STBEmployeeEntryDbContext _Context;

        public STBEmployeeService (STBEmployeeEntryDbContext context) 
        {
            _Context = context;
        }
        public async Task<STBEmployeeEntryTable> CreateEmployeeAsync(STBEmployeeEntryTable Employee)
        {
            _Context.STBEmployeeEntryTables.Add(Employee);
            await _Context.SaveChangesAsync();
            return Employee;
        }

        public async Task DeleteEmploYeeAsync(int id)
        {
            var Employee = await _Context.STBEmployeeEntryTables.FindAsync(id);
            if (Employee != null) 
            {
                _Context.STBEmployeeEntryTables.Remove(Employee);
                await _Context.SaveChangesAsync(true);
            }
        }

        public async Task<IEnumerable<STBEmployeeEntryTable>> GetAllEmployeeAsync()
        {
            return await _Context.STBEmployeeEntryTables.ToListAsync();
        }

        public async Task<STBEmployeeEntryTable> GetEmployeeByIdAsync(int id)
        {
            var res = await _Context.STBEmployeeEntryTables.FindAsync(id);
            return res;
        }

        public async Task UpdateEmploYeeAsync(STBEmployeeEntryTable Employee)
        {
            var Employees = await _Context.STBEmployeeEntryTables.FindAsync(Employee.Id);
            if (Employees == null) 
            {
                _Context.STBEmployeeEntryTables.Update(Employee);
                _Context.Entry(Employee).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
            }
        }
    }
}
