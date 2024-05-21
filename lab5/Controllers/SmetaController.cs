using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebSheff.ApplicationCore.Interfaces.Services;
using WebSheff.ApplicationCore.DomModels;
using WebSheff.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebSheff.Controllers
{
    [Produces("application/json")]
    //[EnableCors]
    //[ApiController]
    public class SmetaController : Controller
    {
        private ISmetaService _smetaService;
        private IUserService _userService;
        private readonly ILogger<SmetaController> _logger;
        public SmetaController(ISmetaService orderService, ILogger<SmetaController> logger)
        {
            _smetaService = orderService;
            _logger = logger;
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

        // GET: api/<SmetaController>
        [HttpGet]
        [Route("api/smeta/getall")]
        public async Task<IActionResult> GetSmetas()
        {
            try
            {
                var smetas = await Task.Run(() => _smetaService.GetAllSmetas());
                if (smetas != null && smetas.Any())
                {
                    _logger.LogExtension("Retrieved all smetas");
                    return Ok(smetas);
                }
                else
                {
                    var errorMsg = new
                    {
                        message = "Сметы не найдены"
                    };
                    _logger.LogExtension("No smetas found");
                    return NotFound(errorMsg);
                }
            }
            catch (Exception ex)
            {
                _logger.LogExtension("Error retrieving smetas", ex, LogLevel.Error);
                var errorMsg = new
                {
                    message = "Ошибка при получении смет",
                    error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorMsg);
            }
        }

        // GET api/<SmetaController>/5
        [HttpGet]
        [Route("api/smeta/getone")]
        public async Task<IActionResult> GetSmetum(int id)
        {
            var smeta = await Task.Run(() => _smetaService.GetSmeta(id));
            if (smeta == null)
            {
                return NotFound();
            }
            return Ok(smeta);
        }

        // POST api/<SmetaController>
        [HttpPost]
        [Route("api/smeta/createone")]
        public async Task<IActionResult> PostSmeta([FromBody] SmetaDTO smeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var smetaCreated = await Task.Run(() => _smetaService.MakeSmeta(
                smeta.IdClient,
                
                smeta.Description,
                smeta.GeneralBudget
                ));

                if (smetaCreated != null)
                {
                    _logger.LogExtension("Smeta created with id", smetaCreated.Id, LogLevel.Information);
                    return CreatedAtAction(nameof(GetSmetum), new { id = smetaCreated.Id }, smetaCreated);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogExtension("Error creating smeta", ex, LogLevel.Error);
                var errorMsg = new
                {
                    message = "Ошибка при обновлении сметы",
                    error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorMsg);
            }
        }

     
    }
}
