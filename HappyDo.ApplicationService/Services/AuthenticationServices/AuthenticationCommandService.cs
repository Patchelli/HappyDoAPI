using HappyDo.ApplicationService.DataTransferObject.Requests.AuthenticationRequest;
using HappyDo.ApplicationService.DataTransferObject.Responses.AuthenticationLoginResponse;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.Business.Interfaces.OthersContracts;
using HappyDo.Business.Providers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Services.AuthenticationServices
{
    public sealed class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly INotificationHandler _notification;
        private readonly IApplicationUserFacadeService _applicationUserFacadeService;
        private readonly JwtTokenOptions _jwtTokenOptions;
        private readonly SymmetricSecurityKey _key;
        private const string SecurityAlgorithm = SecurityAlgorithms.HmacSha256;

        public AuthenticationCommandService(
            INotificationHandler notification,
            IApplicationUserFacadeService applicationUserFacadeService,
            IOptions<JwtTokenOptions> options)
        {
            _notification = notification;
            _applicationUserFacadeService = applicationUserFacadeService;
            _jwtTokenOptions = options.Value;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenOptions.JwtKey));
        }

        public async Task<AuthenticationLoginResponse?> GenerateAccessTokenAsync(UserLoginRequest userLogin)
        {
            if (!await _applicationUserFacadeService.CheckLoginAndPasswordAsyncAsync(userLogin))
            {
                _notification.CreateNotification("Geração do token de acesso", "Login ou senha inválido.");

                return null;
            }

            if (!await _applicationUserFacadeService.ValidateUserStatusAsync(userLogin.Login))
            {
                _notification.CreateNotification(
                    "Validação de status do usuário",
                    "Perfil do usuário consta inativado no sistema");

                return null;
            }

            var authLogin = await GenerateJwtTokenAsync(userLogin.Login);

            return authLogin;
        }

        public async Task<AuthenticationLoginResponse?> GenerateAccessTokenByActiveDirectoryAsync(
            UserLoginRequest userLogin,
            bool successfullyValidated)
        {
            if (!successfullyValidated)
            {
                _notification.CreateNotification("Autenticação AD", "Usuário ou senha invalidos.");

                return null;
            }

            if (!await _applicationUserFacadeService.HasApplicationUserAsync(
                    a => a.NormalizedUserName == userLogin.Login.ToUpper()))
            {
                _notification.CreateNotification("Geração do token de acesso", "Usuário não tem registro no sistema.");

                return null;
            }

            if (!await _applicationUserFacadeService.ValidateUserStatusAsync(userLogin.Login))
            {
                _notification.CreateNotification(
                    "Validação de status do usuário",
                    "Perfil do usuário consta inativado no sistema");

                return null;
            }

            var authLogin = await GenerateJwtTokenAsync(userLogin.Login);

            return authLogin;
        }

        private async Task<AuthenticationLoginResponse> GenerateJwtTokenAsync(string userName)
        {
            var claims = await _applicationUserFacadeService.FindClaimsByUserNameAsync(userName);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(_jwtTokenOptions.DurationInHours),
                Issuer = _jwtTokenOptions.Issuer,
                Audience = _jwtTokenOptions.Audience,
                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithm)
            };

            var tokeHandler = new JwtSecurityTokenHandler();

            var token = tokeHandler.CreateToken(tokenDescription);

            var jwtToken = tokeHandler.WriteToken(token);

            return new AuthenticationLoginResponse
            {
                AccessToken = jwtToken,
                Expiry = _jwtTokenOptions.DurationInHours,
                Message = "autenticado com sucesso."
            };
        }
    }
}
