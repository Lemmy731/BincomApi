using BincomProjectApi.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BincomProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _taxService;
        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }
        [Authorize]
        [HttpPost]  
        public async Task<IActionResult> Calculator(decimal income, decimal rent)
        {
            try
            {
                if(income <= 0 || rent <= 0)
                {
                    return BadRequest("invalid input");
                }
                var tax = _taxService.Calculatetax(income, rent);
                return Ok($"your tax is : {tax}");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
