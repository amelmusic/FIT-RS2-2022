using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _Service;

        public KorisniciController(IKorisniciService service)
        {
            _Service = service;
        }

        [HttpGet]
        public IEnumerable<Korisnici> Get()
        {
            return _Service.Get();
        }

        //[HttpGet("{id}")]
        //public Proizvodi GetById(int id)
        //{
        //    return _proizvodiService.GetById(id);
        //}
    }
}
