using System;
using System.Collections.Generic;

namespace eProdaja.Services.Database
{
    public partial class Kupci
    {
        public Kupci()
        {
            Narudzbes = new HashSet<Narudzbe>();
            Ocjenes = new HashSet<Ocjene>();
        }

        public int KupacId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public DateTime DatumRegistracije { get; set; }
        public string Email { get; set; } = null!;
        public string KorisnickoIme { get; set; } = null!;
        public string LozinkaHash { get; set; } = null!;
        public string LozinkaSalt { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<Narudzbe> Narudzbes { get; set; }
        public virtual ICollection<Ocjene> Ocjenes { get; set; }
    }
}
