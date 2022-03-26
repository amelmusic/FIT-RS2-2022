using System;
using System.Collections.Generic;

namespace eProdaja.Services.Database
{
    public partial class Ulazi
    {
        public Ulazi()
        {
            UlazStavkes = new HashSet<UlazStavke>();
        }

        public int UlazId { get; set; }
        public string BrojFakture { get; set; } = null!;
        public DateTime Datum { get; set; }
        public decimal IznosRacuna { get; set; }
        public decimal Pdv { get; set; }
        public string? Napomena { get; set; }
        public int SkladisteId { get; set; }
        public int KorisnikId { get; set; }
        public int DobavljacId { get; set; }

        public virtual Dobavljaci Dobavljac { get; set; } = null!;
        public virtual Korisnici Korisnik { get; set; } = null!;
        public virtual Skladistum Skladiste { get; set; } = null!;
        public virtual ICollection<UlazStavke> UlazStavkes { get; set; }
    }
}
