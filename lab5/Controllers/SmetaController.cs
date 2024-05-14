using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebSheff.ApplicationCore.Interfaces.Services;
using WebSheff.ApplicationCore.DomModels;

namespace WebSheff.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class SmetaController : ControllerBase
    {
        private ISmetaService _smetaService;
        public SmetaController(ISmetaService orderService)
        {
            _smetaService = orderService;
        }

        // GET: api/<SmetaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Smetum>>> GetSmetas()
        {
            return await Task.Run(_smetaService.GetAllSmetas);
        }

        // GET api/<SmetaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Smetum>> GetSmeta(int id)
        {
            var order = await Task.Run(() => _smetaService.GetSmeta(id));
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST api/<SmetaController>
        [HttpPost]
        public async Task<ActionResult<Smetum>> PostSmeta(Smetum smeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderCreated = await Task.Run(() => _smetaService.MakeSmeta(
                smeta.Client,
                smeta.Executor,
                smeta.SmProvidedService,
                DateTime.Now));

            if (orderCreated != null)
            {
                return CreatedAtAction("PostSmeta", new { id = smeta.Id }, smeta);
            }

            return BadRequest();
        }

        //// PUT api/<SmetaController>/5
        //[HttpPut("{id}")]
        //private void PutSmeta(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SmetaController>/5
        //[HttpDelete("{id}")]
        //private void DeleteSmeta(string id)
        //{
        //}
    }
}
