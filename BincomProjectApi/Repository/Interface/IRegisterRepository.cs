using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;

namespace BincomProjectApi.Repository.Interface
{
    public interface IRegisterRepository
    {
        Task<bool> Register(User user);
    }
}
