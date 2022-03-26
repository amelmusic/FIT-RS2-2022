using System;
using System.Collections.Generic;

namespace eProdaja.Services.Database
{
    public partial class NarudzbaStavke
    {
        public int NarudzbaStavkaId { get; set; }
        public int NarudzbaId { get; set; }
        public int ProizvodId { get; set; }
        public int Kolicina { get; set; }

        public virtual Narudzbe Narudzba { get; set; } = null!;
        public virtual Proizvodi Proizvod { get; set; } = null!;
    }
}
