using AppApi.IRepositories;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private ITaiKhoanRepository _taiKhoanRepository;

        public TaiKhoanController(ITaiKhoanRepository taiKhoanRepository)
        {
            _taiKhoanRepository = taiKhoanRepository;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = _taiKhoanRepository.SignUpAsync(signUpModel);
            if (!result.IsCompletedSuccessfully) return Ok(result.Result);
            return BadRequest(result.Result);
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {

            var result = _taiKhoanRepository.SignInAsync(signInModel);
            if (!result.IsCompletedSuccessfully) return Ok(result.Result);
            return BadRequest(result.Result);
        }
    }
}
