﻿using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("User/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _userServices.GetUserAll();
            return Ok(result);
        }



        [HttpPost("User/create")]
        public async Task<IActionResult> Create([FromBody] UserVM u)
        {
            var result = await _userServices.CreateUser(u);
            return Ok(result);
        }

        [HttpPut("User/update{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserVM u)
        {
            var result = await _userServices.EditUser(u);

            return Ok(result);
        }

        [HttpGet("User/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var u = await _userServices.GetUserById(id);
            return Ok(u);
        }


        [HttpDelete("User/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userServices.DeleteUser(id);
            return Ok(result);
        }
    }
}