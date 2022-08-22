namespace E_Commerce.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<Dtos.Token> LoginAsync(string userNameOrEmail, string password,int accessTokenLifeTime);
    }
}
