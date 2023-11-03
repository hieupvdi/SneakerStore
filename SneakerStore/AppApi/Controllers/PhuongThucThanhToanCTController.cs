using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhuongThucThanhToanCTController : ControllerBase
    {
        private IPhuongThucThanhToanCTServices _phuongThucThanhToanCTServices;
        public PhuongThucThanhToanCTController(IPhuongThucThanhToanCTServices phuongThucThanhToanCTServices)
        {
            _phuongThucThanhToanCTServices = phuongThucThanhToanCTServices;
        }

        [HttpGet("PTTTCT/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _phuongThucThanhToanCTServices.GetPTTTCTAll();
            return Ok(result);
        }



        [HttpPost("PTTTCT/create")]
        public async Task<IActionResult> Create([FromBody] PhuongThucThanhToanCTVM ptct)
        {
            var result = await _phuongThucThanhToanCTServices.CreatePTTTCT(ptct);
            return Ok(result);
        }

        [HttpPut("PTTTCT/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PhuongThucThanhToanCTVM ptct)
        {
            var result = await _phuongThucThanhToanCTServices.EditPTTTCT(ptct);

            return Ok(result);
        }

        [HttpGet("PTTTCT/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ptct = await _phuongThucThanhToanCTServices.GetPTTTCTById(id);
            return Ok(ptct);
        }


        [HttpDelete("PTTTCT/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _phuongThucThanhToanCTServices.DeletePTTTCT(id);
            return Ok(result);
        }
    }
}
