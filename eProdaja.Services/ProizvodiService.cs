using AutoMapper;
using eProdaja.Model;
using eProdaja.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService : IProizvodiService
    {
        public eProdajaContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public ProizvodiService(eProdajaContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public IEnumerable<Model.Proizvodi> Get()
        {
            var result = Context.Proizvodis.ToList();

            return Mapper.Map<List<Model.Proizvodi>>(result);
        }

        public Model.Proizvodi GetById(int id)
        {
            var result = Context.Proizvodis.Find(id);

            return Mapper.Map<Model.Proizvodi>(result);
        }
    }
}
