using AppApi.IRepositories;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    public class KichCoController : Controller
    {
        private IKichCoRepository _kichcoRepository;
        public KichCoController(IKichCoRepository kichcoRepository)
        {
            _kichcoRepository = kichcoRepository;
        }

        [HttpGet("KichCo/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = _kichcoRepository.GetAll();
            if (!result.IsCompletedSuccessfully) return Ok(result.Result);
            return BadRequest(result.Result);
        }



        [HttpPost("KichCo/create")]
        public async Task<IActionResult> Create([FromBody] KichCo kc)
        {
            var result = await _kichcoRepository.Create(kc);
            return Ok(result);
        }

        [HttpPut("KichCo/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] KichCo kc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            kc.Id = id;
            var affectedResult = await _kichcoRepository.Edit(kc);
            if (affectedResult == Guid.Empty)
                return BadRequest();
            return Ok();
        }

        [HttpGet("KichCo/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var kichco = await _kichcoRepository.GetById(id);
            if (kichco == null)
            {
                return BadRequest("Can't find KichCo");
            }
            return Ok(kichco);
        }


        [HttpDelete("KichCo/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var affectedResult = await _kichcoRepository.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
