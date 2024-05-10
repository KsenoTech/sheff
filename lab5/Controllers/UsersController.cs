using WebSheff.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebSheff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class UsersController : ControllerBase
    {
        private readonly SheffContext _context;

        public UsersController(SheffContext context)
        {
            _context = context;            
        }

        [HttpGet("UserWithProvidedServices")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersWithProvidedServices()
        {
            return await _context.Users.Include(user => user.ProvidedServices).ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            // Удаляем все связанные записи в таблице VidRabot
            //var relatedVidRabot = _context.VidRabot.Where(v => v.IdExecutor == id);
            //_context.VidRabot.RemoveRange(relatedVidRabot);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET api/<UsersController>/5
        [HttpGet("Name_f_{id}")]
        public string Get(int id)
        {
            // Здесь вы можете использовать идентификатор для получения конкретного пользователя из вашей базы данных
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            // Проверяем, был ли найден пользователь
            if (user != null)
            {
                // Возвращаем какое-то значение для этого пользователя
                return user.Name;
            }
            else
            {
                // Если пользователь не найден, возвращаем сообщение об ошибке
                return "Пользователь не найден";
            }
        }
    }
}


