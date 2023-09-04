using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class PhoneNumber : BaseEntity 
    {
        public string Number { get; set;}
        public string PreFix { get; set; }        
        public int idPersonFk { get; set; }
        public Person Person { get; set; } 
    }
}