using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangCTController : ControllerBase
    {
        private IGioHangCTServices _gioHangCTServices;
        public GioHangCTController(IGioHangCTServices gioHangCTServices)
        {
            _gioHangCTServices = gioHangCTServices;
        }

        [HttpGet("GioHangCT/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _gioHangCTServices.GetGioHangCTAll();
            return Ok(result);
        }



        [HttpPost("GioHangCT/create")]
        public async Task<IActionResult> Create([FromBody] GioHangCTVM ghct)
        {
            var result = await _gioHangCTServices.CreateGioHangCT(ghct);
            return Ok(result);
        }

        [HttpPut("GioHangCT/update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] GioHangCTVM ghct)
        {
            var result = await _gioHangCTServices.EditGioHangCT(ghct);

            return Ok(result);
        }

        [HttpGet("GioHangCT/ById/")]
        public async Task<IActionResult> GetById(Guid iduser,Guid idctsp)
        {
            var ghct = await _gioHangCTServices.GetGioHangCTById(iduser,idctsp);
            return Ok(ghct);
        }

        [HttpGet("GioHangCT/{id}")]
        public async Task<IActionResult> GetGHUser(Guid id)
        {
            var ghct = await _gioHangCTServices.GetGioHangCTUser(id);
            return Ok(ghct);
        }


        [HttpDelete("GioHangCT/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _gioHangCTServices.DeleteGioHangCT(id);
            return Ok(result);
        }
    }
}
