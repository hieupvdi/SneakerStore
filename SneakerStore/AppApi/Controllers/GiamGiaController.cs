
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    public class GiamGiaController : Controller
    {
        //private IGiamGiaRepository _giamgiaRepository;
        //public GiamGiaController(IGiamGiaRepository giamgiaRepository)
        //{
        //    _giamgiaRepository = giamgiaRepository;
        //}

        //[HttpGet("GiamGia/get-all")]
        //public async Task<IActionResult> GetAll()
        //{

        //    var result = _giamgiaRepository.GetAll();
        //    if (!result.IsCompletedSuccessfully) return Ok(result.Result);
        //    return BadRequest(result.Result);
        //}



        //[HttpPost("GiamGia/create")]
        //public async Task<IActionResult> Create([FromBody] GiamGia gg)
        //{
        //    var result = await _giamgiaRepository.Create(gg);
        //    return Ok(result);
        //}

        //[HttpPut("GiamGia/update{id}")]

        //public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] GiamGia gg)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    gg.Id = id;
        //    var affectedResult = await _giamgiaRepository.Edit(gg);
        //    if (affectedResult == Guid.Empty)
        //        return BadRequest();
        //    return Ok();
        //}

        //[HttpGet("AnhSP/{id}")]
        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    var giamgia = await _giamgiaRepository.GetById(id);
        //    if (giamgia == null)
        //    {
        //        return BadRequest("Can't find giamgia");
        //    }
        //    return Ok(giamgia);
        //}


        //[HttpDelete("GiamGia/{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var affectedResult = await _giamgiaRepository.Delete(id);
        //    if (affectedResult == 0)
        //        return BadRequest();
        //    return Ok();
        //}
    }
}
