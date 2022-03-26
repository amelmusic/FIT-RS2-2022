using System;
using System.Collections.Generic;

namespace eProdaja.Services.Database
{
    public partial class Skladistum
    {
        public Skladistum()
        {
            Izlazis = new HashSet<Izlazi>();
            Ulazis = new HashSet<Ulazi>();
        }

        public int SkladisteId { get; set; }
        public string Naziv { get; set; } = null!;
        public string? Adresa { get; set; }
        public string? Opis { get; set; }

        public virtual ICollection<Izlazi> Izlazis { get; set; }
        public virtual ICollection<Ulazi> Ulazis { get; set; }
    }
}
