using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProductStateMachine
{
    public class InitialProductState : BaseState
    {
        public override void Insert(ProizvodiInsertRequest request)
        {
            //call entity framework to persist data...

            CurrentEntity.StateMachine = "draft";
        }

    }
}
