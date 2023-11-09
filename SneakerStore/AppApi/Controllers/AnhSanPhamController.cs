using AppData.IServices;
using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnhSanPhamController : Controller
    {
        private IAnhSanPhamServices _anhSanPhamServices;
        public AnhSanPhamController(IAnhSanPhamServices anhSanPhamServices)
        {
            _anhSanPhamServices = anhSanPhamServices;
        }

        [HttpGet("AnhSanPham/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result =await _anhSanPhamServices.GetASPAll();
            return Ok(result);
        }



        [HttpPost("AnhSanPham/create")]
        public async Task<IActionResult> Create([FromBody] AnhSanPhamVM asp)
        {
            var result = await _anhSanPhamServices.CreateASP(asp);
            return Ok(result);
        }

        [HttpPut("AnhSanPham/update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AnhSanPhamVM asp)
        {
            var result = await _anhSanPhamServices.EditASP(asp);
       
            return Ok(result);
        }

        [HttpGet("AnhSanPham/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var sp = await _anhSanPhamServices.GetASPById(id);      
            return Ok(sp);
        }


        [HttpDelete("AnhSanPham/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _anhSanPhamServices.DeleteASP(id);
            return Ok(result);
        }
    }
}
