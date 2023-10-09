using AppApi.IRepositories;
using AppApi.Repositories;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    public class MauSacController : Controller
    {
        private IMauSacRepository _mausacRepository;
        public MauSacController(IMauSacRepository mausacRepository)
        {
            _mausacRepository = mausacRepository;
        }

        [HttpGet("MauSac/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = _mausacRepository.GetAll();
            if (!result.IsCompletedSuccessfully) return Ok(result.Result);
            return BadRequest(result.Result);
        }

       

        [HttpPost("MauSac/create")]
        public async Task<IActionResult> Create([FromBody] MauSac ms)
        {
            var result = await _mausacRepository.Create(ms);
            return Ok(result);
        }

        [HttpPut("MauSac/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] MauSac ms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ms.ID = id;
            var affectedResult = await _mausacRepository.Edit(ms);
            if (affectedResult == Guid.Empty)
                return BadRequest();
            return Ok();
        }

        [HttpGet("MauSac/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var mausac = await _mausacRepository.GetById(id);
            if (mausac == null)
            {
                return BadRequest("Can't find chucvu");
            }
            return Ok(mausac);
        }

        
        [HttpDelete("MauSac/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var affectedResult = await _mausacRepository.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

    }
}
