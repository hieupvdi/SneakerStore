using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private IHoaDonServices _hoaDonServices;
        public HoaDonController(IHoaDonServices hoaDonServices)
        {
            _hoaDonServices = hoaDonServices;
        }

        [HttpGet("HoaDon/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = _hoaDonServices.GetHoaDonAll();
            return Ok(result);
        }



        [HttpPost("HoaDon/create")]
        public async Task<IActionResult> Create([FromBody] HoaDonVM hd)
        {
            var result = await _hoaDonServices.CreateHoaDon(hd);
            return Ok(result);
        }

        [HttpPut("HoaDon/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] HoaDonVM hd)
        {
            var result = await _hoaDonServices.EditHoaDon(hd);

            return Ok(result);
        }

        [HttpGet("HoaDon/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var hd = await _hoaDonServices.GetHoaDonById(id);
            return Ok(hd);
        }


        [HttpDelete("HoaDon/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _hoaDonServices.DeleteHoaDon(id);
            return Ok(result);
        }
    }
}
