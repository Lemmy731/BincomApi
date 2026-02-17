using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Shared.GenericResponse;

namespace BincomProjectApi.Service.Interface
{
    public interface IGallaryService
    {
        Task<ApiResponse<string>> UpLoadGallery(GalleryDto galleryDto);
        Task<ApiResponse<string>> DownLoadGallery(string id);
    }
}
