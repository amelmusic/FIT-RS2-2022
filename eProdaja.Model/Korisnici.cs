using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public partial class Korisnici
    {
    
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; } 
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public bool? Status { get; set; }

        //public virtual ICollection<Izlazi> Izlazis { get; set; }
        //public virtual ICollection<KorisniciUloge> KorisniciUloges { get; set; }
        //public virtual ICollection<Ulazi> Ulazis { get; set; }
    }
}
