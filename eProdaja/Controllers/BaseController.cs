using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        public IService<T, TSearch> Service { get; set; }

        public BaseController(IService<T, TSearch> service)
        {
            Service = service;
        }

        [HttpGet]
        public IEnumerable<T> Get([FromQuery]TSearch search = null)
        {
            return Service.Get(search);
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return Service.GetById(id);
        }
    }
}
