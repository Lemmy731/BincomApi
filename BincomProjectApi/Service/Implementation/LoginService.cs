using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Model.JwtModel;
using BincomProjectApi.Repository.Interface;
using BincomProjectApi.Service.Interface;
using BincomProjectApi.Service.JWT.Implementation;
using BincomProjectApi.Service.JWT.Interface;
using BincomProjectApi.Shared.GenericResponse;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace BincomProjectApi.Service.Implementation
{
    public class LoginService: ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IJwtTokenService _jwtTokenService;
        public LoginService(ILoginRepository loginRepository, IJwtTokenService jwtTokenService)
        {
            _loginRepository = loginRepository;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<ApiResponse<string>> Login(LoginDto loginDto)
        {
            var user = await _loginRepository.Login(loginDto);
            if(user.StatusCode == StatusCodes.Status200OK)
            {
                var jwtClaims = new JwtClaimsModel
                {
                    Id = user.Data.Id,  
                    Email = user.Data.Email,
                    FirstName = user.Data.FirstName,
                    LastName = user.Data.LastName,
                    IssuedAt = DateTime.Now
                };
                var accessToken = _jwtTokenService.GenerateAccessTokenAsync(jwtClaims);
                if (accessToken != null)
                {
                    return ApiResponse<string>.Success("jwt token generated", accessToken);
                }
            }
            return ApiResponse<string>.Failure(StatusCodes.Status400BadRequest,"no user found");
        }
    }
}
