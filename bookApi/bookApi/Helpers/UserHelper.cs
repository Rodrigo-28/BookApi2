using System.Security.Claims;

namespace bookApi.Helpers
{
    public class UserHelper
    {
        public static int GetRequiredUserId(ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("Id is missing");
            }

            return Int32.Parse(userId);

        }
        public static int? GetOptionalUserId(ClaimsPrincipal user)
        {
            var userId = user?.FindFirstValue(ClaimTypes.NameIdentifier);

            return !string.IsNullOrEmpty(userId) ? Int32.Parse(userId) : null;

        }
    }
}
