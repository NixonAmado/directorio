using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly directorioContext _context;
        private IPerson _persons;
        private IPhoneNumber _phoneNumbers;

        public UnitOfWork(directorioContext directorioContext) 
        {
            _context = directorioContext;
        }

        public IPerson Persons
        {
            get
            {
                if (_persons == null)
                {
                    _persons = new PersonRepository(_context);
                }
                return _persons;
            }
        }

        public IPhoneNumber PhoneNumbers
        {
            get
            {
                if (_phoneNumbers == null)
                {
                    _phoneNumbers = new PhoneNumberRepository(_context);
                }
                return _phoneNumbers;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}