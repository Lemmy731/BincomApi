using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Shared.GenericResponse;

namespace BincomProjectApi.Service.Interface
{
    public interface ILoginService
    {
        Task<ApiResponse<string>> Login(LoginDto loginDto);
    }
}
