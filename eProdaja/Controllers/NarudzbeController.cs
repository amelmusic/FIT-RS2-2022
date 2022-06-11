using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;

namespace eProdaja.Controllers
{
    public class NarudzbeController : BaseCRUDController<Model.Narudzbe, BaseSearchObject, NarudzbaInsertRequest, NarudzbaUpdateRequest>
    {
        public NarudzbeController(INarudzbeService service)
            : base(service)
        {
        }
    }
}
