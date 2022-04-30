using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.SearchObjects
{
    public class KorisniciSearchObject : BaseSearchObject
    {
        public string KorisnickoIme { get; set; }
        public string NameFTS { get; set; }

        public string Email { get; set; }

        public bool IncludeRoles { get; set; }

    }
}
