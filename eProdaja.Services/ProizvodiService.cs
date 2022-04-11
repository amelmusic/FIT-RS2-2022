using AutoMapper;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using eProdaja.Services.ProductStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService : BaseCRUDService<Model.Proizvodi, Database.Proizvodi, ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest>, IProizvodiService
    {
        public BaseState BaseState { get; set; }
        public ProizvodiService(eProdajaContext context, IMapper mapper, BaseState baseState)
            : base(context, mapper)
        {
            BaseState = baseState;
        }

        public override Model.Proizvodi Insert(ProizvodiInsertRequest insert)
        {
            //return base.Insert(insert);
            var state = BaseState.CreateState("initial");
           
            return state.Insert(insert);
        }

        public override Model.Proizvodi Update(int id, ProizvodiUpdateRequest update)
        {
            var product = Context.Proizvodis.Find(id);
            //return base.Update(id, update);
            var state = BaseState.CreateState(product.StateMachine);
            state.CurrentEntity = product;

            state.Update(update);

            return GetById(id);
        }

        public Model.Proizvodi Activate(int id)
        {
            var product = Context.Proizvodis.Find(id);
            //return base.Update(id, update);
            var state = BaseState.CreateState(product.StateMachine);
            state.CurrentEntity = product;

            state.Activate();

            return GetById(id);
        }

        public List<string> AllowedActions(int id)
        {
            var product = GetById(id);
            var state = BaseState.CreateState(product.StateMachine);

            return state.AllowedActions();
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
