using AppData.IServices;
using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    public class AnhSanPhamController : Controller
    {
        private IAnhSanPhamServices _anhSanPhamServices;
        public AnhSanPhamController(IAnhSanPhamServices anhSanPhamServices)
        {
            _anhSanPhamServices = anhSanPhamServices;
        }

        [HttpGet("AnhSP/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = _anhSanPhamServices.GetASPAll();
            if (!result.IsCompletedSuccessfully) return Ok(result.Result);
            return BadRequest(result.Result);
        }



        [HttpPost("AnhSP/create")]
        public async Task<IActionResult> Create([FromBody] AnhSanPhamVM asp)
        {
            var result = await _anhSanPhamServices.CreateASP(asp);
            return Ok(result);
        }

        [HttpPut("AnhSP/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AnhSanPhamVM asp)
        {
            var result = await _anhSanPhamServices.EditASP(asp);
       
            return Ok(result);
        }

        [HttpGet("AnhSP/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var sp = await _anhSanPhamServices.GetASPById(id);      
            return Ok(sp);
        }


        [HttpDelete("AnhSP/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _anhSanPhamServices.DeleteASP(id);
            return Ok(result);
        }
    }
}
