using System;
using System.Collections.Generic;

namespace eProdaja.Services.Database
{
    public partial class Dobavljaci
    {
        public Dobavljaci()
        {
            Ulazis = new HashSet<Ulazi>();
        }

        public int DobavljacId { get; set; }
        public string Naziv { get; set; } = null!;
        public string? KontaktOsoba { get; set; }
        public string Adresa { get; set; } = null!;
        public string Telefon { get; set; } = null!;
        public string? Fax { get; set; }
        public string? Web { get; set; }
        public string Email { get; set; } = null!;
        public string? ZiroRacuni { get; set; }
        public string? Napomena { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Ulazi> Ulazis { get; set; }
    }
}
