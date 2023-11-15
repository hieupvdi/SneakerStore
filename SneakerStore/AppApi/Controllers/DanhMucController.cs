using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private IDanhMucServices _danhMucServices;
        public DanhMucController(IDanhMucServices danhMucServices)
        {
            _danhMucServices = danhMucServices;
        }

        [HttpGet("DanhMuc/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _danhMucServices.GetDanhMucAll();
            return Ok(result);
        }



        [HttpPost("DanhMuc/create")]
        public async Task<IActionResult> Create([FromBody] DanhMucVM dm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _danhMucServices.CreateDanhMuc(dm);
            return Ok(result);
        }

        [HttpPut("DanhMuc/update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DanhMucVM dm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _danhMucServices.EditDanhMuc(dm);

            return Ok(result);
        }

        [HttpGet("DanhMuc/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dm = await _danhMucServices.GetDanhMucById(id);
            return Ok(dm);
        }


        [HttpDelete("DanhMuc/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _danhMucServices.DeleteDanhMuc(id);
            return Ok(result);
        }
    }
}
