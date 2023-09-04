
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class PhoneNumberRepository : GenericRepository<PhoneNumber>,IPhoneNumber
    {
        private readonly directorioContext _context;
        public PhoneNumberRepository(directorioContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<PhoneNumber> GetByIdAsync (int id)
        {
            return await _context.PhoneNumbers
            .Include(p => p.Person)
            .FirstOrDefaultAsync(p => p.idPersonFk == id);
        } 

        public override async Task<IEnumerable<PhoneNumber>> GetAllAsync()
        {
            return await _context.PhoneNumbers
            .Include(p => p.Person)
            .ToListAsync();
        } 
    }
}