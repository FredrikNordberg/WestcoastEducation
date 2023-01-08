using westcoast_education.web.Models;

namespace westcoast_education.web.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person?> FindByPersonEmailAsync(string personemail);
    }
}