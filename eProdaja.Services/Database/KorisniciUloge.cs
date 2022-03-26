using System;
using System.Collections.Generic;

namespace eProdaja.Services.Database
{
    public partial class KorisniciUloge
    {
        public int KorisnikUlogaId { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }
        public DateTime DatumIzmjene { get; set; }

        public virtual Korisnici Korisnik { get; set; } = null!;
        public virtual Uloge Uloga { get; set; } = null!;
    }
}
