using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaChiController : ControllerBase
    {
        private IDiaChiServices _diaChiServices;
        public DiaChiController(IDiaChiServices diaChiServices)
        {
            _diaChiServices = diaChiServices;
        }

        [HttpGet("DiaChi/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _diaChiServices.GetDiaChiAll();
            return Ok(result);
        }



        [HttpPost("DiaChi/create")]
        public async Task<IActionResult> Create([FromBody] DiaChiVM dc)
        {
            var result = await _diaChiServices.CreateDiaChi(dc);
            return Ok(result);
        }

        [HttpPut("DiaChi/update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DiaChiVM dc)
        {
            var result = await _diaChiServices.EditDiaChi(dc);

            return Ok(result);
        }

        [HttpGet("DiaChi/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dc = await _diaChiServices.GetDiaChiById(id);
            return Ok(dc);
        }


        [HttpDelete("DiaChi/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _diaChiServices.DeleteDiaChi(id);
            return Ok(result);
        }
    }
}
