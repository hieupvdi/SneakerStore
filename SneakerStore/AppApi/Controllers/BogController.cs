using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BogController : ControllerBase
    {
        private IBogServices _bogServices;
        public BogController(IBogServices bogServices)
        {
            _bogServices = bogServices;
        }

        [HttpGet("Bog/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _bogServices.GetBogAll();
            return Ok(result);
        }



        [HttpPost("Bog/create")]
        public async Task<IActionResult> Create([FromBody] BogVM bog)
        {
            var result = await _bogServices.CreateBog(bog);
            return Ok(result);
        }

        [HttpPut("Bog/update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] BogVM bog)
        {
            var result = await _bogServices.EditBog(bog);

            return Ok(result);
        }

        [HttpGet("Bog/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var bog = await _bogServices.GetBogById(id);
            return Ok(bog);
        }


        [HttpDelete("Bog/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bogServices.DeleteBog(id);
            return Ok(result);
        }
    }
}
