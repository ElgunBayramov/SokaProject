using Soka.Domain.Models.Entities.Membership;

namespace Soka.Domain.AppCode.Services
{
    public interface ITokenService
    {
        string BuildToken(SokaUser user);
        bool ValidateToken(string token);
    }
}