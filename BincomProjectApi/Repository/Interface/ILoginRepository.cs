using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Shared.GenericResponse;

namespace BincomProjectApi.Repository.Interface
{
    public interface ILoginRepository
    {
        Task<ApiResponse<User>> Login(LoginDto loginDto);
    }
}
