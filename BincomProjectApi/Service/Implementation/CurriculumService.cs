using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Repository.Interface;
using BincomProjectApi.Service.Interface;
using BincomProjectApi.Shared.GenericResponse;

namespace BincomProjectApi.Service.Implementation
{
    public class CurriculumService : ICurriculumService
    {
        private readonly ICurriculumRepository _upLoadCurriculumRepository;
        public CurriculumService(ICurriculumRepository upLoadCurriculumRepository)
        {
            _upLoadCurriculumRepository = upLoadCurriculumRepository;
        }
        public async Task<ApiResponse<string>> UpLoadCurriculum(CurriculumDto curriculumDto)
        {
            try
            {
                CurriculumVitae curriculumVitae = new CurriculumVitae
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = curriculumDto.Title,
                    JobRole = curriculumDto.JobRole,
                    DateCreated = DateTime.Now,
                    Url = curriculumDto.Url
                };
                var check = await _upLoadCurriculumRepository.UpLoadCurriculum(curriculumVitae);
                if (check)
                {
                    return ApiResponse<string>.Success("successfully uploaded", "success");
                }
                return ApiResponse<string>.Failure(StatusCodes.Status400BadRequest, "unable to upload");
            }
            catch (Exception ex) 
            {
                return ApiResponse<string>.Failure(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
    }
}
