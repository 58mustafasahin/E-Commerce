﻿using E_Commerce.Application.Abstractions.Services;
using MediatR;

namespace E_Commerce.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.UserNameOrEmail, request.Password, 15);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };
        }
    }
}
