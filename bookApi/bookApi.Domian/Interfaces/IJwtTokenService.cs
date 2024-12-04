using bookApi.Domian.Models;

namespace bookApi.Domian.Interfaces
{
    public interface IJwtTokenService
    {
        public string GenerateJwtToken(User user);

    }
}
