using Microsoft.EntityFrameworkCore;
using STBEmployeeEntry.Model;
using STBEmployeeEntry.Service;

namespace STBEmployeeEntry.Data
{
    public class STBEmployeeEntryDbContext :DbContext
    {
        public STBEmployeeEntryDbContext(DbContextOptions<STBEmployeeEntryDbContext>options): base(options) 
        {
        }
        //
        public DbSet<STBEmployeeEntryTable> STBEmployeeEntryTables { get; set; }
    }
}
