using westcoast_education.web.Models;

namespace westcoast_education.web.Interfaces
{
    public interface IPersonRepository
    {
        Task<IList<Person>>ListAllAsync();
        Task<Person?> FindByIdAsync(int id);
        Task<Person?> FindByEmailAsync(string email);
        Task<bool> AddAsync(Person person);
        Task<bool> UpdateAsync(Person person);
        Task<bool> DeleteAsync(Person person);
        Task<bool> SaveAsync();
    }
}