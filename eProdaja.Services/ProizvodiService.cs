using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService : IProizvodiService
    {
        public List<Proizvodi> ProizvodiList = new List<Proizvodi>() { new Proizvodi() { Id = 1, Naziv = "Laptop" }, new Proizvodi() { Id = 2, Naziv = "Mis" } };
        public IEnumerable<Proizvodi> Get()
        {
            ProizvodiList.Add(new Proizvodi() { Naziv = "Test DI", Id = -1 });
            return ProizvodiList;
        }

        public Proizvodi GetById(int id)
        {
            return ProizvodiList.FirstOrDefault(x => x.Id == id);
        }
    }
}
