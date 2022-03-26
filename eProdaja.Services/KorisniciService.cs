using AutoMapper;
using eProdaja.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class KorisniciService : IKorisniciService
    {
        public eProdajaContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public KorisniciService(eProdajaContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public IEnumerable<Model.Korisnici> Get()
        {
            var result = Context.Korisnicis.ToList();

            return Mapper.Map<List<Model.Korisnici>>(result);
        }
    }
}
