using E_Commerce.Application.Dtos.User;

namespace E_Commerce.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser createUser);
    }
}
