using System.Security.Claims;

namespace Recipe.Common.Interfaces
{
    public interface IUserService
    {
        ClaimsPrincipal GetUser();
    }
}
