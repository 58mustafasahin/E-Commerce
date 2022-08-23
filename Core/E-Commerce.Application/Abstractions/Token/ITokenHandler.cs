namespace E_Commerce.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        Dtos.Token CreateAccessToken(int second);
        string CreateRefreshToken();
    }
}
