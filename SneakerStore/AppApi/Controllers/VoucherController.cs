using AppData.IServices;
using AppData.Services;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private IVoucherServices _voucherServices;
        public VoucherController(IVoucherServices voucherServices)
        {
            _voucherServices = voucherServices;
        }

        [HttpGet("Voucher/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = _voucherServices.GetVoucherAll();
            return Ok(result);
        }



        [HttpPost("Voucher/create")]
        public async Task<IActionResult> Create([FromBody] VoucherVM vo)
        {
            var result = await _voucherServices.CreateVoucher(vo);
            return Ok(result);
        }

        [HttpPut("Voucher/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] VoucherVM vo)
        {
            var result = await _voucherServices.EditVoucher(vo);

            return Ok(result);
        }

        [HttpGet("Voucher/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vo = await _voucherServices.GetVoucherById(id);
            return Ok(vo);
        }


        [HttpDelete("Voucher/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _voucherServices.DeleteVoucher(id);
            return Ok(result);
        }
    }
}
