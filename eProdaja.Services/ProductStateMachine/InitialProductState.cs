using AutoMapper;
using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProductStateMachine
{
    public class InitialProductState : BaseState
    {
        public InitialProductState(IServiceProvider serviceProvider, eProdajaContext context, IMapper mapper)
            : base(serviceProvider, context, mapper)
        {
        }

        public override Model.Proizvodi Insert(ProizvodiInsertRequest request)
        {
            var set = Context.Set<Database.Proizvodi>();

            Database.Proizvodi entity = Mapper.Map<Database.Proizvodi>(request);

            CurrentEntity = entity;
            CurrentEntity.StateMachine = "draft";

            set.Add(entity);

            Context.SaveChanges();

            return Mapper.Map<Model.Proizvodi>(entity);
        }
    }
}
