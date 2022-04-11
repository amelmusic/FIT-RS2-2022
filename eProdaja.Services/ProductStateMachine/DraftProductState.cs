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
    public class DraftProductState : BaseState
    {
        public DraftProductState(IServiceProvider serviceProvider, eProdajaContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }

        public override void Update(ProizvodiUpdateRequest request)
        {
            var set = Context.Set<Database.Proizvodi>();

            Mapper.Map(request, CurrentEntity);
            CurrentEntity.StateMachine = "draft";

            Context.SaveChanges();
 
            //update data by calling EF...
        }

        public override void Activate()
        {
            CurrentEntity.StateMachine = "active";
            Context.SaveChanges();
            //update data by calling EF...
        }

        public override List<string> AllowedActions()
        {
            var list = base.AllowedActions();

            list.Add("update");
            list.Add("activate");
            list.Add("hide");

            return list;
        }
    }
}
