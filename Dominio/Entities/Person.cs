using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set;}
        public string SurName { get; set;}
        public string Age { get; set;}
        public int IdPhoneNumberFk { get; set;}
        public PhoneNumber PhoneNumber { get; set; } 
        
    }
}