using System.Security.Claims;

namespace Web_Api_JWT.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetMyName()
        {
            var result = string.Empty;
            result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            return result;

        }
    }
}