using Microsoft.AspNetCore.Http;
using Recipe.Common.Interfaces;
using System.Security.Claims;

namespace Recipe.Common.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _accessor;

        public UserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public ClaimsPrincipal GetUser()
        {
            return _accessor?.HttpContext?.User;
        }
    }
}
