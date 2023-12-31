﻿using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private IChucVuServices _chucVuServices;
        public ChucVuController(IChucVuServices chucVuServices)
        {
            _chucVuServices = chucVuServices;
        }

        [HttpGet("ChucVu/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _chucVuServices.GetChucVuAll();
            return Ok(result);
        }



        [HttpPost("ChucVu/create")]
        public async Task<IActionResult> Create([FromBody] ChucVuVM cv)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _chucVuServices.CreateChucVu(cv);
            return Ok(result);
        }

        [HttpPut("ChucVu/update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ChucVuVM cv)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _chucVuServices.EditChucVu(cv);

            return Ok(result);
        }

        [HttpGet("ChucVu/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var sp = await _chucVuServices.GetChucVuById(id);
            return Ok(sp);
        }


        [HttpDelete("ChucVu/delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _chucVuServices.DeleteChucVu(id);
            return Ok(result);
        }
    }
}
