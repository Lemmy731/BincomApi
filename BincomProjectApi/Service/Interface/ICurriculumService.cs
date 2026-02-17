using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Shared.GenericResponse;

namespace BincomProjectApi.Service.Interface
{
    public interface ICurriculumService
    {
        Task<ApiResponse<string>> UpLoadCurriculum(CurriculumDto curriculumDto);
    }
}
