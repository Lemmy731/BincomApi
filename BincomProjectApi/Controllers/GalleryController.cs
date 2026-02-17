using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BincomProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGallaryService _gallaryService;
        public GalleryController(IGallaryService upLoadGallaryService)
        {
            _gallaryService = upLoadGallaryService;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserGallery([FromBody]GalleryDto galleryDto)
        {
            try
            {
                var response = await _gallaryService.UpLoadGallery(galleryDto);

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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GalleryGet(string id)
        {
            try
            {
                var response = await _gallaryService.DownLoadGallery(id);

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
