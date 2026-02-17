using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Shared.GenericResponse; 
namespace BincomProjectApi.Repository.Interface
{
    public interface IGallaryRepository
    {
        Task<bool> UpLoadGallery(Gallery galleryDto);
        Task<ApiResponse<string>> DownLoadGallery(string id);
    }
}
