using System;
using System.Collections.Generic;

namespace eProdaja.Services.Database
{
    public partial class UlazStavke
    {
        public int UlazStavkaId { get; set; }
        public int UlazId { get; set; }
        public int ProizvodId { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }

        public virtual Proizvodi Proizvod { get; set; } = null!;
        public virtual Ulazi Ulaz { get; set; } = null!;
    }
}
