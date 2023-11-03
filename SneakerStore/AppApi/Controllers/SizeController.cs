using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private ISizeServices _sizeServices;
        public SizeController(ISizeServices sizeServices)
        {
            _sizeServices = sizeServices;
        }

        [HttpGet("Size/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _sizeServices.GetSizeAll();
            return Ok(result);
        }



        [HttpPost("Size/create")]
        public async Task<IActionResult> Create([FromBody] SizeVM si)
        {
            var result = await _sizeServices.CreateSize(si);
            return Ok(result);
        }

        [HttpPut("Size/update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SizeVM si)
        {
            var result = await _sizeServices.EditSize(si);

            return Ok(result);
        }

        [HttpGet("Size/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var si = await _sizeServices.GetSizeById(id);
            return Ok(si);
        }


        [HttpDelete("Size/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _sizeServices.DeleteSize(id);
            return Ok(result);
        }
    }
}
