using System.Security.Claims;

namespace bookApi.Application.Interfaces
{
    public interface IUserHelper
    {
        int GetRequiredUserId(ClaimsPrincipal user);
        int? GetOptionalUserId(ClaimsPrincipal user);
    }
}
