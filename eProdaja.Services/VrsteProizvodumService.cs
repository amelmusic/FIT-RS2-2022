using AutoMapper;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class VrsteProizvodumService : BaseCRUDService<Model.VrsteProizvodum, Database.VrsteProizvodum, VrsteProizvodumSearchObject, VrsteProizvodumUpsertRequest, VrsteProizvodumUpsertRequest>, IVrsteProizvodumService
    {
        public VrsteProizvodumService(eProdajaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<VrsteProizvodum> AddFilter(IQueryable<VrsteProizvodum> query, VrsteProizvodumSearchObject search = null)
        {
            var filteredQuery =  base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.NazivGT))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.StartsWith(search.NazivGT));
            }

            return filteredQuery;
        }
    }
}
