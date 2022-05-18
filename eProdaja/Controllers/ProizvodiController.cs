using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodiController :  BaseCRUDController<Model.Proizvodi, ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest>
    {
        public IProizvodiService ProizvodiService { get; set; }
        public ProizvodiController(IProizvodiService proizvodiService)
            :base(proizvodiService)
        {
            ProizvodiService = proizvodiService;
        }


        [HttpPut("{id}/Activate")]
        public Model.Proizvodi Activate(int id)
        {
            var result = ProizvodiService.Activate(id);

            return result;
        }

        [HttpPut("{id}/AllowedActions")]
        public List<string> AllowedActions(int id)
        {
            var result = ProizvodiService.AllowedActions(id);

            return result;
        }

        [HttpGet("{id}/Recommend")]
        [AllowAnonymous]
        public List<Proizvodi> Recommend(int id)
        {
            var result = ProizvodiService.Recommend(id);

            return result;
        }

    }
}
