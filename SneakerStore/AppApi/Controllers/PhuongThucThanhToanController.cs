using AppData.IServices;
using AppData.Services;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhuongThucThanhToanController : ControllerBase
    {
        private IPhuongThucThanhToanServices _phuongThucThanhToanServices;
        public PhuongThucThanhToanController(IPhuongThucThanhToanServices phuongThucThanhToanServices)
        {
            _phuongThucThanhToanServices = phuongThucThanhToanServices;
        }

        [HttpGet("PTTT/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = _phuongThucThanhToanServices.GetPTTTAll();
            return Ok(result);
        }



        [HttpPost("PTTT/create")]
        public async Task<IActionResult> Create([FromBody] PhuongThucThanhToanVM pt)
        {
            var result = await _phuongThucThanhToanServices.CreatePTTT(pt);
            return Ok(result);
        }

        [HttpPut("PTTT/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PhuongThucThanhToanVM pt)
        {
            var result = await _phuongThucThanhToanServices.EditPTTT(pt);

            return Ok(result);
        }

        [HttpGet("PTTT/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var pt = await _phuongThucThanhToanServices.GetPTTTById(id);
            return Ok(pt);
        }


        [HttpDelete("PTTT/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _phuongThucThanhToanServices.DeletePTTT(id);
            return Ok(result);
        }
    }
}
