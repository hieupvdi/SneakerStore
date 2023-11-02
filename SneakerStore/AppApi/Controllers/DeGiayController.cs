using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeGiayController : ControllerBase
    {
        private IDeGiayServices _deGiayServices;
        public DeGiayController(IDeGiayServices deGiayServices)
        {
            _deGiayServices = deGiayServices;
        }

        [HttpGet("DeGiay/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _deGiayServices.GetDeGiayAll();
            return Ok(result);
        }



        [HttpPost("DeGiay/create")]
        public async Task<IActionResult> Create([FromBody] DeGiayVM dg)
        {
            var result = await _deGiayServices.CreateDeGiay(dg);
            return Ok(result);
        }

        [HttpPut("DeGiay/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DeGiayVM dg)
        {
            var result = await _deGiayServices.EditDeGiay(dg);

            return Ok(result);
        }

        [HttpGet("DeGiay/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dg = await _deGiayServices.GetDeGiayById(id);
            return Ok(dg);
        }


        [HttpDelete("DeGiay/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _deGiayServices.DeleteDeGiay(id);
            return Ok(result);
        }
    }
}
