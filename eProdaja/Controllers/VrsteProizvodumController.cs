using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;

namespace eProdaja.Controllers
{
    public class VrsteProizvodumController : BaseCRUDController<Model.VrsteProizvodum, VrsteProizvodumSearchObject, VrsteProizvodumUpsertRequest, VrsteProizvodumUpsertRequest>
    {
        public VrsteProizvodumController(IVrsteProizvodumService service)
            : base(service)
        {
        }
    }
}
