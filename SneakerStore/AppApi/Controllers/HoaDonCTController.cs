using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonCTController : ControllerBase
    {
        private IHoaDonCTServices _hoaDonCTServices;
        public HoaDonCTController(IHoaDonCTServices hoaDonCTServices)
        {
            _hoaDonCTServices = hoaDonCTServices;
        }

        [HttpGet("HoaDonCT/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _hoaDonCTServices.GetHoaDonCTAll();
            return Ok(result);
        }



        [HttpPost("HoaDonCT/create")]
        public async Task<IActionResult> Create([FromBody] HoaDonCTVM hdct)
        {
            var result = await _hoaDonCTServices.CreateHoaDonCT(hdct);
            return Ok(result);
        }

        [HttpPut("HoaDonCT/update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] HoaDonCTVM hdct)
        {
            var result = await _hoaDonCTServices.EditHoaDonCT(hdct);

            return Ok(result);
        }

        [HttpGet("HoaDonCT/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var hdct = await _hoaDonCTServices.GetHoaDonCTById(id);
            return Ok(hdct);
        }
        [HttpGet("HoaDonCT/GetHDCTUser/{id}")]
        public async Task<IActionResult> GetHDCTUser(Guid id)
        {
            var hdct = await _hoaDonCTServices.GetHDCTUser(id);
            return Ok(hdct);
        }

        [HttpDelete("HoaDonCT/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _hoaDonCTServices.DeleteHoaDonCT(id);
            return Ok(result);
        }
    }
}
