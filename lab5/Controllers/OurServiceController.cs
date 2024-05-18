using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSheff.ApplicationCore.DomModels;
using WebSheff.ApplicationCore.Interfaces.Services;
using WebSheff.Infrastructure.Extensions;

namespace WebSheff.Controllers
{
    [Produces("application/json")]
    //[EnableCors]
    //[ApiController]
    public class OurServicesController : Controller
    {
        private IProvidedServiceService _ourservices;
        private readonly ILogger<OurServicesController> _logger;
        public OurServicesController(IProvidedServiceService ourService, ILogger<OurServicesController> logger)
        {
            _ourservices = ourService;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/ourservice/getall")]
        public async Task<IActionResult> GetAllServices()
        {
            try
            {
                var services = await Task.Run(() => _ourservices.GetAllProvidedServices());
                if (services != null && services.Any())
                {
                    _logger.LogExtension("Retrieved all provided services");
                    return Ok(new { message = "Услуги успешно получены", services });
                }
                else
                {
                    var errorMsg = new
                    {
                        message = "Услуги не найдены"
                    };
                    _logger.LogExtension("No services found");
                    return NotFound(errorMsg);
                }
            }
            catch (Exception ex)
            {
                _logger.LogExtension("Error retrieving services", ex, LogLevel.Error);
                var errorMsg = new
                {
                    message = "Ошибка при получении услуг",
                    error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorMsg);
            }
        }


        // GET api/<OurServicesController>/5
        [HttpGet]
        [Route("api/ourservice/getone")]
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
        [Route("api/ourservice/createservice")]
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
                return CreatedAtAction("PostService", new { id = serviceNew.Id }, serviceNew);
            }

            return BadRequest();
        }

        // PUT api/<OurServicesController>/5
        [HttpPut]
        [Route("api/ourservice/updateservice")]
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
        //[HttpDelete]
        //[Route("api/ourservice/deleteservice")]
        //public async Task<IActionResult> DeleteService(int id)
        //{
        //    var serviceDeleted = await Task.Run(() => _ourservices.DeleteProvidedService(id));

        //    if (serviceDeleted)
        //    {
        //        return Ok();
        //    }
        //    return NotFound();
        //}
        [HttpDelete]
        [Route("api/ourservice/deleteservice")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var serviceDeleted = await Task.Run(() => _ourservices.DeleteProvidedService(id));

            if (serviceDeleted)
            {
                _logger.LogExtension("Deleted provided service with id", id);
                return Ok();
            }
            else
            {
                var errorMsg = new
                {
                    message = "Услуга не найдена или не удалось удалить"
                };
                _logger.LogExtension("Failed to delete provided service with id", id, LogLevel.Error);
                return NotFound(errorMsg);
            }
        }


    }
}
