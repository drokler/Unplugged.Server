using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using Unplugged.Server.Database;
using UnpluggedModel;

namespace Unplugged.Server.Services
{
    public class UserService : UnpluggedModel.UserService.UserServiceBase
    {
        private readonly UPContext _ctx;

        public UserService(UPContext ctx)
        {
            _ctx = ctx;
        }
        [AllowAnonymous]
        public override async Task<AuthResponse> Auth(AuthRequest request, ServerCallContext context)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(t =>
                t.Login == request.Login && t.Password == request.Password);
            if (user == null)
            {
                return new AuthResponse
                {
                    Status = ResponseStatus.RsError,
                    ResponseDescription = "Имя пользователя или пароль введены не верно."
                };
            }

            var token = JwtTokenValidator.GetToken(user.Login, user.Role.ToString());
            return new AuthResponse
            {
                Token = token,
                Status = ResponseStatus.RsOk
            };
        }
        [Authorize(Policy = nameof(UserRole.Common))]
        public override Task<EmptyResponse> IsLogin(EmptyRequest request, ServerCallContext context)
        {
            return Task.FromResult(new EmptyResponse
            {
                Status = ResponseStatus.RsOk
            });
        }
    }
}