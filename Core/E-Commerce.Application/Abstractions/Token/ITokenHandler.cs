using E_Commerce.Domain.Entities.Identity;

namespace E_Commerce.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        Dtos.Token CreateAccessToken(int second, AppUser user);
        string CreateRefreshToken();
    }
}
