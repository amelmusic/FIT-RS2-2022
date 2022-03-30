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
    public class ProizvodiService : BaseCRUDService<Model.Proizvodi, Database.Proizvodi, ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest>, IProizvodiService
    {
        public ProizvodiService(eProdajaContext context, IMapper mapper)
            : base(context, mapper)
        {

        }


        //public override IEnumerable<Model.Proizvodi> Get(ProizvodiSearchObject search = null)
        //{
        //    return base.Get(search);
        //}

        public override IEnumerable<Model.Proizvodi> Get(ProizvodiSearchObject search = null)
        {
            return base.Get(search);
        }


        public override IQueryable<Database.Proizvodi> AddFilter(IQueryable<Database.Proizvodi> query, ProizvodiSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Sifra))
            {
                filteredQuery = filteredQuery.Where(x=>x.Sifra == search.Sifra);
            }

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.Naziv)); 
            }

            return filteredQuery;
        }

        //public IEnumerable<Model.Proizvodi> Get(ProizvodiSearchObject search)
        //{

        //}

        //public List<Model.Proizvodi> GetByName(string name)
        //{
        //    var result = Context.Proizvodis.Where(x=>x.Naziv == name).ToList();
        //}
        //public List<Model.Proizvodi> GetByNameStartingWith(string name)
        //{
        //    var result = Context.Proizvodis.Where(x => x.Naziv.StartsWith(name)).ToList();
        //}

        //public List<Model.Proizvodi> GetByNameStartingWithOrByCode(string name)
        //{

        //}


    }
}
