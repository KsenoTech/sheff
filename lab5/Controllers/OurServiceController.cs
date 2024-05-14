using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSheff.ApplicationCore.DomModels;
using WebSheff.ApplicationCore.Interfaces.Services;

namespace WebSheff.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class OurServicesController : Controller
    {
        private IProvidedServiceService _ourservices;
        public OurServicesController(IProvidedServiceService ourService)
        {
            _ourservices = ourService;
        }

        // GET: api/<OurServicesController>
        [HttpGet("GetAllOurServices")]       
        public async Task<ActionResult<IEnumerable<ProvidedService>>> GetAllServices()
        {
            return await Task.Run(_ourservices.GetAllProvidedServices);
        }

        // GET api/<OurServicesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProvidedService>> GetService(int id)
        {
            var service = await Task.Run(() => _ourservices.GetProvidedService(id));
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        // POST api/<OurServicesController>
        [HttpPost]
        public async Task<ActionResult<ProvidedService>> PostService(ProvidedService serviceNew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var serviceCreated = await Task.Run(() => _ourservices.CreateProvidedService(
                serviceNew.Description,
                serviceNew.Title,
                serviceNew.CostOfM ?? 0,
                serviceNew.CostOfM2 ?? 0));

            if (serviceCreated)
            {
                return CreatedAtAction("PostCar", new { id = serviceNew.Id }, serviceNew);
            }

            return BadRequest();
        }

        // PUT api/<OurServicesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, ProvidedService service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            var serviceUpdated = await Task.Run(() => _ourservices.UpdateProvidedService(service));
            if (serviceUpdated)
            {
                return Ok(service);
            }
            return NotFound();
        }

        // DELETE api/<OurServicesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var serviceDeleted = await Task.Run(() => _ourservices.DeleteProvidedService(id));

            if (serviceDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

    }
}
