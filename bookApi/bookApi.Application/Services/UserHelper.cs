using bookApi.Application.Interfaces;
using System.Security.Claims;

namespace bookApi.Application.Services;
public class UserHelper : IUserHelper
{
    public int GetRequiredUserId(ClaimsPrincipal user)
    {
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("Id is missing");
        }

        return Int32.Parse(userId);
    }

    public int? GetOptionalUserId(ClaimsPrincipal user)
    {
        var userId = user?.FindFirstValue(ClaimTypes.NameIdentifier);

        return !string.IsNullOrEmpty(userId) ? Int32.Parse(userId) : null;

    }
}

