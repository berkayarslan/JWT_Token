using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web_Api_JWT.Models;
using Web_Api_JWT.Security;
using Web_Api_JWT.Service;

namespace Web_Api_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration  _config;
        private readonly IUserService _userService;

        public LoginController(AppDbContext context, IConfiguration config,IUserService userService)
        {
            _context = context;
            _config = config;
            _userService = userService;

        }

        [HttpPost]
        public IActionResult AuthLogin(User user)
        {
            //user var mı ? varsa token oluştur.
            bool isUser = ControlUser(user.UserName, user.Password);
            if (isUser)
            {
                //token üretelim.
                Token token = TokenHandler.CreateToken(user, _config);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet,Authorize]
        public IActionResult GetMe()
        {
            //claimtype adını dönsün.
            var user = _userService.GetMyName();
            return Ok(user);

        }


        /// <summary>
        /// içerde kullanıcı var mı yok mu kontrolu saglar.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool ControlUser(string username,string password)
        {
            bool result=_context.Users.Any(x=>x.UserName == username && x.Password == password);
            return result;
        }
    }
}
