using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BincomProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumController : ControllerBase
    {
        private readonly ICurriculumService _curriculumService;
        public CurriculumController(ICurriculumService upLoadCurriculumService)
        {
            _curriculumService = upLoadCurriculumService;
        }
        [Authorize]
        [HttpPost]   
        public async Task<IActionResult> UserCurriculum([FromBody]CurriculumDto curriculumDto)
        {
            try
            {
                var response = await _curriculumService.UpLoadCurriculum(curriculumDto);
                if (response.StatusCode == StatusCodes.Status200OK)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);  
            } 
        }
    }
}
