
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class PersonRepository : GenericRepository<Person>,IPerson
    {
        private readonly directorioContext _context;
        public PersonRepository(directorioContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Person> GetByIdAsync (int id)
        {
            return await _context.Persons
            .Include(p => p.PhoneNumber)
            .FirstOrDefaultAsync(p => p.IdPhoneNumberFk == id);
        } 

        public override async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons
            .Include(p => p.PhoneNumber)
            .ToListAsync();
        } 
    }
}