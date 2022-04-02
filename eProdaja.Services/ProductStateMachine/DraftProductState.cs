using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProductStateMachine
{
    public class DraftProductState : BaseState
    {
        public override void Update(ProizvodiUpdateRequest request)
        {
            CurrentEntity.StateMachine = "draft";
            //update data by calling EF...
        }

        public override void Activate()
        {
            CurrentEntity.StateMachine = "active";
            //update data by calling EF...
        }
    }
}
