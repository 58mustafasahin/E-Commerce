using E_Commerce.Application.Abstractions.Services;
using E_Commerce.Application.Dtos.User;
using E_Commerce.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateAsync(new()
            {
                NameSurname = request.NameSurname,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm
            });

            return new()
            {
                Succeeded = response.Succeeded,
                Message = response.Message,
            };

            //throw new UserCreateFailedException();
        }
    }
}
