namespace E_Commerce.Application.Abstractions.Services.Authentications
{
    public interface IExternalAuthentication
    {
        Task<Dtos.Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime);
        Task<Dtos.Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
    }
}
