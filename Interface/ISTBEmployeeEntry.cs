using STBEmployeeEntry.Model;

namespace STBEmployeeEntry.Interface
{
    public interface ISTBEmployeeEntry
    {
        Task<IEnumerable<STBEmployeeEntryTable>> GetAllEmployeeAsync();
        Task<STBEmployeeEntryTable> GetEmployeeByIdAsync(int id);
        Task<STBEmployeeEntryTable> CreateEmployeeAsync(STBEmployeeEntryTable Employee);
        Task UpdateEmploYeeAsync(STBEmployeeEntryTable Employee);
        Task DeleteEmploYeeAsync(int id);
    }
}
