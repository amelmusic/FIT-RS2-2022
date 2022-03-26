using System;
using System.Collections.Generic;

namespace eProdaja.Services.Database
{
    public partial class Korisnici
    {
        public Korisnici()
        {
            Izlazis = new HashSet<Izlazi>();
            KorisniciUloges = new HashSet<KorisniciUloge>();
            Ulazis = new HashSet<Ulazi>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string KorisnickoIme { get; set; } = null!;
        public string LozinkaHash { get; set; } = null!;
        public string LozinkaSalt { get; set; } = null!;
        public bool? Status { get; set; }

        public virtual ICollection<Izlazi> Izlazis { get; set; }
        public virtual ICollection<KorisniciUloge> KorisniciUloges { get; set; }
        public virtual ICollection<Ulazi> Ulazis { get; set; }
    }
}
