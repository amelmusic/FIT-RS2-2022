using AutoMapper;
using eProdaja.Model;
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
    public class JediniceMjereService : BaseCRUDService<Model.JediniceMjere, Database.JediniceMjere, JediniceMjereSearchObject, JediniceMjereUpsertRequest, JediniceMjereUpsertRequest>, IJediniceMjereService
    {
        public JediniceMjereService(eProdajaContext context, IMapper mapper)
        :base (context, mapper){
        }

        public override IQueryable<Database.JediniceMjere> AddFilter(IQueryable<Database.JediniceMjere> query, JediniceMjereSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if(!string.IsNullOrEmpty(search?.Naziv))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv == search.Naziv);
            }

            if(search?.JediniceMjereId.HasValue == true)
            {
                filteredQuery = filteredQuery.Where(x => x.JedinicaMjereId == search.JediniceMjereId);
            }

            return filteredQuery;
        }

    }
}
