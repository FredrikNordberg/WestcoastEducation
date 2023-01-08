using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;

namespace westcoast_education.web.Repository;

    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(WestcoastEducationContext context) : base(context) { }

        public async Task<Person?> FindByPersonEmailAsync(string personemail)
        {
            return await _context.Persons.SingleOrDefaultAsync(c => c.PersonEmail.Trim().ToLower() == personemail.Trim().ToLower());
        }
    }
    
        
        

        
