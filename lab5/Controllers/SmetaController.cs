using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebSheff.ApplicationCore.Interfaces.Services;
using WebSheff.ApplicationCore.Models;

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
        public async Task<ActionResult<IEnumerable<Smeta>>> GetSmetas()
        {
            return await Task.Run(_smetaService.GetAllSmetas);
        }

        // GET api/<SmetaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Smeta>> GetSmeta(int id)
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
        public async Task<ActionResult<Smeta>> PostSmeta(Smeta order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderCreated = await Task.Run(() => _smetaService.MakeSmeta(
                order.IdClient,
                order.IdExecutor,
                order.IdProvededServices,
                DateTime.Now));

            if (orderCreated != null)
            {
                return CreatedAtAction("PostSmeta", new { id = order.Id }, order);
            }

            return BadRequest();
        }

        // PUT api/<SmetaController>/5
        [HttpPut("{id}")]
        private void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SmetaController>/5
        [HttpDelete("{id}")]
        private void Delete(int id)
        {
        }
    }
}
