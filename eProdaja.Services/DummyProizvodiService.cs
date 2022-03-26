
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class DummyProizvodiService : IProizvodiService
    {
        public DummyProizvodiService()
        {
            
        }

        public List<Proizvodi> ProizvodiList = new List<Proizvodi>() { new Proizvodi() { ProizvodId = 1, Naziv = "Laptop" }, new Proizvodi() { ProizvodId = 2, Naziv = "Mis" } };
        public IEnumerable<Proizvodi> Get()
        {
            ProizvodiList.Add(new Proizvodi() { Naziv = "Test DI", ProizvodId = -1 });
            return ProizvodiList;
        }

        public Proizvodi GetById(int id)
        {
            return ProizvodiList.FirstOrDefault(x => x.ProizvodId == id);
        }
    }
}
