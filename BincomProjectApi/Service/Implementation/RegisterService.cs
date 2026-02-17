using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Repository.Interface;
using BincomProjectApi.Service.Interface;
using BincomProjectApi.Shared.GenericResponse;

namespace BincomProjectApi.Service.Implementation
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;

        public RegisterService(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }
        public async Task<ApiResponse<string>> Register(RegisterDto registerDto)
        {
            try
            {
                User user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Email = registerDto.Email,
                    PasswordHash = registerDto.Password,
                    UserName = registerDto.FirstName
                };
                var db = await _registerRepository.Register(user);
                if (db)
                {
                    return ApiResponse<string>.Success("user register successfully", "success");
                }
                return ApiResponse<string>.Failure(StatusCodes.Status400BadRequest, "unable to register user");
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Failure(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
