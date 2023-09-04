using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces;
    public interface IUnitOfWork
    {
        IPerson Persons {get;}
        IPhoneNumber PhoneNumbers {get;}
        Task<int> SaveAsync();

    }
