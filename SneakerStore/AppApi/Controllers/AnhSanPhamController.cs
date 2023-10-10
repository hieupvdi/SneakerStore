using AppApi.IRepositories;
using AppApi.Repositories;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    public class AnhSanPhamController : Controller
    {
        private IAnhSanPhamRepository _anhsanphamRepository;
        public AnhSanPhamController(IAnhSanPhamRepository anhsanphamRepository)
        {
            _anhsanphamRepository = anhsanphamRepository;
        }

        [HttpGet("AnhSP/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = _anhsanphamRepository.GetAll();
            if (!result.IsCompletedSuccessfully) return Ok(result.Result);
            return BadRequest(result.Result);
        }



        [HttpPost("AnhSP/create")]
        public async Task<IActionResult> Create([FromBody] AnhSanPham asp)
        {
            var result = await _anhsanphamRepository.Create(asp);
            return Ok(result);
        }

        [HttpPut("AnhSP/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AnhSanPham asp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            asp.ID = id;
            var affectedResult = await _anhsanphamRepository.Edit(asp);
            if (affectedResult == Guid.Empty)
                return BadRequest();
            return Ok();
        }

        [HttpGet("AnhSP/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var sp = await _anhsanphamRepository.GetById(id);
            if (sp == null)
            {
                return BadRequest("Can't find Anh SP");
            }
            return Ok(sp);
        }


        [HttpDelete("AnhSP/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var affectedResult = await _anhsanphamRepository.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
