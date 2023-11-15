using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaController : ControllerBase
    {
        private IGiamGiaServices _giamGiaServices;
        public GiamGiaController(IGiamGiaServices giamGiaServices)
        {
            _giamGiaServices = giamGiaServices;
        }

        [HttpGet("GiamGia/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _giamGiaServices.GetGiamGiaAll();
            return Ok(result);
        }



        [HttpPost("GiamGia/create")]
        public async Task<IActionResult> Create([FromBody] GiamGiaVM gg)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _giamGiaServices.CreateGiamGia(gg);
            return Ok(result);
        }

        [HttpPut("GiamGia/update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] GiamGiaVM gg)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _giamGiaServices.EditGiamGia(gg);

            return Ok(result);
        }

        [HttpGet("GiamGia/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var gg = await _giamGiaServices.GetGiamGiaById(id);
            return Ok(gg);
        }


        [HttpDelete("GiamGia/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _giamGiaServices.DeleteGiamGia(id);
            return Ok(result);
        }
    }
}
