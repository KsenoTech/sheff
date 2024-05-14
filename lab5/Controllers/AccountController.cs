using WebSheff.ApplicationCore.DomModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSheff.Infrastructure.Extensions;

namespace WebSheff.Controllers
{
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }



        [HttpPost]
        [Route("api/account/register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    Surname = model.Surname,
                    Name = model.Name,
                    MiddleName = model.MiddleName,
                    Email = model.Email,
                    EMail = model.Email,
                    Address = model.Address,
                    TelephoneNumber = model.TelephoneNumber,
                    UserLogin = model.UserLogin,
                    UserName = model.UserLogin,
                    Password = model.Password,
                    NormalizedEmail = model.Email,
                    NormalizedUserName = model.UserLogin.ToUpper()
                };

                // Добавление нового пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogExtension("Created User", user);
                    // Установка роли User
                    await _userManager.AddToRoleAsync(user, "user");
                    // Установка куки
                    await _signInManager.SignInAsync(user, false);
                    return Ok(new { message = "Добавлен новый пользователь: " + user.UserLogin });
                }
                else
                {
                    _logger.LogExtension("Error created User", user, LogLevel.Error);
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    var errorMsg = new
                    {
                        message = "Пользователь не добавлен",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return Created("", errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Неверные входные данные",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                return Created("", errorMsg);
            }

        }



        [HttpPost]
        [Route("api/account/login")]
        //[AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //var userL = await _userManager.FindByNameAsync(model.UserLogin);
                //var userP = await _userManager.CheckPasswordAsync(userL, model.Password);
                var result = await _signInManager.PasswordSignInAsync(model.UserLogin, model.Password, model.RememberMe, false);
                _logger.LogExtension(result);
                if (result.Succeeded)
                { 
                    var user = await _userManager.FindByNameAsync(model.UserLogin);
                    IList<string>? roles = await _userManager.GetRolesAsync(user);
                    string? userRole = roles.FirstOrDefault();
                    _logger.LogExtension("Entered User", user);
                    return Ok(new { message = "Выполнен вход", userName = model.UserLogin, userRole });
                }
                else
                {
                    _logger.LogExtension("Incorrect username or password", "", LogLevel.Error);
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    var errorMsg = new
                    {
                        message = "Вход не выполнен",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return Created("", errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Вход не выполнен",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                _logger.LogExtension("Error", errorMsg, LogLevel.Error);
                return Created("", errorMsg);
            }
        }



        [HttpPost]
        [Route("api/account/logoff")]
        public async Task<IActionResult> LogOff()
        {
            User usr = await GetCurrentUserAsync();
            if (usr == null)
            {
                _logger.LogExtension("Need to enter", "", LogLevel.Warning);
                return Unauthorized(new { message = "Сначала выполните вход" });
            }
            // Удаление куки
            await _signInManager.SignOutAsync();
            _logger.LogExtension("Log out:", usr);
            return Ok(new { message = "Выполнен выход", userName = usr.UserLogin });
        }



        [HttpGet]
        [Route("api/account/isauthenticated")]
        public async Task<IActionResult> IsAuthenticated()
        {
            User usr = await GetCurrentUserAsync();
            if (usr == null)
            {
                _logger.LogExtension("You are guest, need to enter", "", LogLevel.Warning);
                return Unauthorized(new { message = "Вы Гость. Пожалуйста, выполните вход" });
            }
            IList<string> roles = await _userManager.GetRolesAsync(usr);
            string? userRole = roles.FirstOrDefault();
            _logger.LogExtension("Session activated for", usr);
            return Ok(new { message = "Сессия активна", userName = usr.UserLogin, userRole });

        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }

}
