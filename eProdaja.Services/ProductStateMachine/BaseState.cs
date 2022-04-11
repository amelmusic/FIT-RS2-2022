using AutoMapper;
using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProductStateMachine
{
    public class BaseState
    {
        public IMapper Mapper { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public BaseState(IServiceProvider serviceProvider, eProdajaContext context, IMapper mapper)
        {
            Context = context;
            ServiceProvider = serviceProvider;
            Mapper = mapper;
        }

        public Database.Proizvodi CurrentEntity { get; set; }
        public string CurrentState { get; set; }

        public eProdajaContext Context { get; set; } = null;

        public virtual Model.Proizvodi Insert(ProizvodiInsertRequest request)
        {
            throw new Exception("Not allowed");
        }

        public virtual void Update(ProizvodiUpdateRequest request)
        {
            throw new Exception("Not allowed");
        }

        public virtual void Activate()
        {
            throw new Exception("Not allowed");
        }

        public virtual void Hide()
        {
            throw new Exception("Not allowed");
        }

        public virtual void Delete()
        {
            throw new Exception("Not allowed");
        }

        public BaseState CreateState(string stateName)
        {   
            switch (stateName)
            {
                case "initial":
                    return ServiceProvider.GetService<InitialProductState>();
                    break;
                case "draft":
                    return ServiceProvider.GetService<DraftProductState>();
                case "active":
                    return ServiceProvider.GetService<ActiveProductState>();
                default:
                    throw new Exception("Not supported");
             }
        }

        public virtual List<string> AllowedActions()
        {
            return new List<string>();
        }


    }
}
