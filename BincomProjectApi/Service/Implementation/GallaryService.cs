using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Repository.Interface;
using BincomProjectApi.Service.Interface;
using BincomProjectApi.Shared.GenericResponse;

namespace BincomProjectApi.Service.Implementation
{
    public class GallaryService : IGallaryService
    {
        private readonly IGallaryRepository _upLoadGallaryRepository;
        public GallaryService(IGallaryRepository upLoadGallaryRepository)
        {
            _upLoadGallaryRepository = upLoadGallaryRepository;
        }
        public async Task<ApiResponse<string>> UpLoadGallery(GalleryDto galleryDto)
        {
            try
            {
                Gallery gallery = new Gallery
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = galleryDto.Title,
                    Url = galleryDto.Url,
                    Color = galleryDto.Color
                };
                var saveGallery = await _upLoadGallaryRepository.UpLoadGallery(gallery);
                if (saveGallery)
                {
                    return ApiResponse<string>.Success("save successfully", "success");
                }
                return ApiResponse<string>.Failure(StatusCodes.Status400BadRequest, "unable to save");
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Failure(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        public async Task<ApiResponse<string>> DownLoadGallery(string id)
        {
            try
            {
                var gallery = await _upLoadGallaryRepository.DownLoadGallery(id);
                if (gallery.StatusCode == StatusCodes.Status200OK)
                {
                    return ApiResponse<string>.Success("successfully", gallery.Data);
                }
                return ApiResponse<string>.Failure(StatusCodes.Status400BadRequest, gallery.Data);
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Failure(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
