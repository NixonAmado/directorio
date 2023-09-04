using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Cors;

    public class PhoneNumberDto
    {
        public int Id {get;set;}
        public string Number {get;set;}
        public string PreFix {get;set;}
        public string IdPersonFk {get;set;}


    }
