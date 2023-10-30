using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        private IGioHangServices _gioHangServices;
        public GioHangController(IGioHangServices gioHangServices)
        {
            _gioHangServices = gioHangServices;
        }

        [HttpGet("GioHang/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = _gioHangServices.GetGioHangAll();
            return Ok(result);
        }



        [HttpPost("GioHang/create")]
        public async Task<IActionResult> Create([FromBody] GioHangVM gh)
        {
            var result = await _gioHangServices.CreateGioHang(gh);
            return Ok(result);
        }

        [HttpPut("GioHang/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] GioHangVM gh)
        {
            var result = await _gioHangServices.EditGioHang(gh);

            return Ok(result);
        }

        [HttpGet("GioHang/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var gh = await _gioHangServices.GetGioHangById(id);
            return Ok(gh);
        }


        [HttpDelete("GioHang/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _gioHangServices.DeleteGioHang(id);
            return Ok(result);
        }
    }
}
