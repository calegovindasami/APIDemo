using APIDemo.Models;
using APIDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientController : ControllerBase
    {
        private IRecipientService _service;
        public RecipientController(IRecipientService service)
        {
            _service = service;
        }

        [HttpPost]
        public Recipient Add(Recipient recipient)
        {
            var result = _service.Add(recipient);
            return result;
        }

        [HttpGet]
        public List<Recipient> Get()
        {
            return _service.Get();
        }
    }
}
