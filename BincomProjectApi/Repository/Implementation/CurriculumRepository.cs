using BincomProjectApi.Model.Entities;
using BincomProjectApi.Repository.Data;
using BincomProjectApi.Repository.Interface;

namespace BincomProjectApi.Repository.Implementation
{
    public class CurriculumRepository : ICurriculumRepository
    {
        private readonly AppDbContext _appDbContext;
        public CurriculumRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> UpLoadCurriculum(CurriculumVitae curriculumVitae)
        {
            try
            {
                await _appDbContext.CurriculumVitaes.AddAsync(curriculumVitae);
                var check = await _appDbContext.SaveChangesAsync();
                if(check > 0)
                {
                    return true;
                }
                return false;    
            }
            catch (Exception ex) 
            {
                return false;
            }
          
            
        }
    }
}
