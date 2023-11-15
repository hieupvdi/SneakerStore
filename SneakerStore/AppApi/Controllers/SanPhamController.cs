using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamServices _sanPhamServices;
        public SanPhamController(ISanPhamServices sanPhamServices)
        {
            _sanPhamServices = sanPhamServices;
        }

        [HttpGet("SanPham/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _sanPhamServices.GetSanPhamAll();
            return Ok(result);
        }



        [HttpPost("SanPham/create")]
        public async Task<IActionResult> Create([FromBody] SanPhamVM sp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _sanPhamServices.CreateSanPham(sp);
            return Ok(result);
        }

        [HttpPut("SanPham/update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SanPhamVM sp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _sanPhamServices.EditSanPham(sp);

            return Ok(result);
        }

        [HttpGet("SanPham/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var sp = await _sanPhamServices.GetSanPhamById(id);
            return Ok(sp);
        }


        [HttpDelete("SanPham/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _sanPhamServices.DeleteSanPham(id);
            return Ok(result);
        }
    }
}
