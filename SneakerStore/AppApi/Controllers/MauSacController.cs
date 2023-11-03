using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MauSacController : ControllerBase
    {
        private IMauSacServices _mauSacServices;
        public MauSacController(IMauSacServices mauSacServices)
        {
            _mauSacServices = mauSacServices;
        }

        [HttpGet("MauSac/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _mauSacServices.GetMauSacAll();
            return Ok(result);
        }



        [HttpPost("MauSac/create")]
        public async Task<IActionResult> Create([FromBody] MauSacVM ms)
        {
            var result = await _mauSacServices.CreateMauSac(ms);
            return Ok(result);
        }

        [HttpPut("MauSac/update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] MauSacVM ms)
        {
            var result = await _mauSacServices.EditMauSac(ms);

            return Ok(result);
        }

        [HttpGet("MauSac/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ms = await _mauSacServices.GetMauSacById(id);
            return Ok(ms);
        }


        [HttpDelete("MauSac/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mauSacServices.DeleteMauSac(id);
            return Ok(result);
        }
    }
}
