using E_Commerce.Application.Abstractions.Services.Authentications;

namespace E_Commerce.Application.Abstractions.Services
{
    public interface IAuthService : IExternalAuthentication, IInternalAuthentication
    {


    }
}
