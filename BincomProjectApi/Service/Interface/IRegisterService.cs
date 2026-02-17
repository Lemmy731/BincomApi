using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Shared.GenericResponse;

namespace BincomProjectApi.Service.Interface
{
    public interface IRegisterService
    {
        Task<ApiResponse<string>> Register(RegisterDto registerDto);
    }
}
