using AppApi.IRepositories;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    public class LoaiSnaPhamController : Controller
    {
        private ILoaiSanPhamRepository _loaisanphamRepository;
        public LoaiSnaPhamController(ILoaiSanPhamRepository loaisanphamRepository)
        {
            _loaisanphamRepository = loaisanphamRepository;
        }

        [HttpGet("LoaiSP/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = _loaisanphamRepository.GetAll();
            if (!result.IsCompletedSuccessfully) return Ok(result.Result);
            return BadRequest(result.Result);
        }



        [HttpPost("LoaiSP/create")]
        public async Task<IActionResult> Create([FromBody] LoaiSanPham ls)
        {
            var result = await _loaisanphamRepository.Create(ls);
            return Ok(result);
        }

        [HttpPut("LoaiSP/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] LoaiSanPham ls)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ls.ID = id;
            var affectedResult = await _loaisanphamRepository.Edit(ls);
            if (affectedResult == Guid.Empty)
                return BadRequest();
            return Ok();
        }

        [HttpGet("LoaiSP/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var loaisp = await _loaisanphamRepository.GetById(id);
            if (loaisp == null)
            {
                return BadRequest("Can't find Loai SP");
            }
            return Ok(loaisp);
        }


        [HttpDelete("LoaiSP/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var affectedResult = await _loaisanphamRepository.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
