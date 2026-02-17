using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;

namespace BincomProjectApi.Repository.Interface
{
    public interface ICurriculumRepository
    {
        Task<bool> UpLoadCurriculum(CurriculumVitae curriculumVitae);
    }
}
