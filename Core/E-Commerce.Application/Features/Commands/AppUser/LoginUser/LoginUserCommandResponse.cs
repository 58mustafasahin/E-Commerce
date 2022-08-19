using E_Commerce.Application.Dtos;

namespace E_Commerce.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {

    }

    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }

    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
        public string Message { get; set; }
    }
}
