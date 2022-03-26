using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JediniceMjereController : ControllerBase
    {
        private readonly IJediniceMjereService _service;

        public JediniceMjereController(IJediniceMjereService proizvodiService)
        {
            _service = proizvodiService;
        }

        [HttpGet]
        public IEnumerable<JediniceMjere> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public JediniceMjere GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
