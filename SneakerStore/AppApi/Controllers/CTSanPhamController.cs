using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTSanPhamController : ControllerBase
    {
        private ICTSanPhamServices _ctsanPhamServices;
        public CTSanPhamController(ICTSanPhamServices ctsanPhamServices)
        {
            _ctsanPhamServices = ctsanPhamServices;
        }

        [HttpGet("CTSanPham/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = _ctsanPhamServices.GetCTSanPhamAll();
            return Ok(result);
        }



        [HttpPost("CTSanPham/create")]
        public async Task<IActionResult> Create([FromBody] CTSanPhamVM ctsp)
        {
            var result = await _ctsanPhamServices.CreateCTSanPham(ctsp);
            return Ok(result);
        }

        [HttpPut("CTSanPham/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CTSanPhamVM ctsp)
        {
            var result = await _ctsanPhamServices.EditCTSanPham(ctsp);

            return Ok(result);
        }

        [HttpGet("CTSanPham/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ctsp = await _ctsanPhamServices.GetCTSanPhamById(id);
            return Ok(ctsp);
        }


        [HttpDelete("CTSanPham/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _ctsanPhamServices.DeleteCTSanPham(id);
            return Ok(result);
        }
    }
}
