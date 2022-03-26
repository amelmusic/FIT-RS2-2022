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
    public class JediniceMjereService : IJediniceMjereService
    {
        public eProdajaContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public JediniceMjereService(eProdajaContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public IEnumerable<Model.JediniceMjere> Get()
        {
            var result = Context.JediniceMjeres.ToList();

            return Mapper.Map<List<Model.JediniceMjere>>(result);
        }

        public Model.JediniceMjere GetById(int id)
        {
            var result = Context.Proizvodis.Find(id);

            return Mapper.Map<Model.JediniceMjere>(result);
        }
    }
}
