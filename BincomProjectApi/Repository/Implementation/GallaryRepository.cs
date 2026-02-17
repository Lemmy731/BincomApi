using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Repository.Data;
using BincomProjectApi.Repository.Interface;
using BincomProjectApi.Shared.GenericResponse;
using Microsoft.EntityFrameworkCore;

namespace BincomProjectApi.Repository.Implementation
{
    public class GallaryRepository: IGallaryRepository
    {
        private readonly AppDbContext _appDbContext;
        public GallaryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> UpLoadGallery(Gallery gallery)
        {
            try
            {
                await _appDbContext.Galleries.AddAsync(gallery);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<ApiResponse<string>> DownLoadGallery(string id)
        {
            try
            {
                if(id != null)
                {
                    var gallery =  await _appDbContext.Galleries.Where(x => x.Id == id).FirstOrDefaultAsync();     
                    if(gallery != null)
                    {
                        return ApiResponse<string>.Success("success", gallery.Url);
                    }
                    return ApiResponse<string>.Failure(StatusCodes.Status404NotFound, "not data found");
                }
                return ApiResponse<string>.Failure(StatusCodes.Status404NotFound, "not found");
            }
            catch (Exception ex) 
            {
                return ApiResponse<string>.Failure(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
