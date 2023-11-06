using AppData.IServices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IBlogServices _blogServices;
        public BlogController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }

        [HttpGet("Blog/get-all")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _blogServices.GetBlogAll();
            return Ok(result);
        }



        [HttpPost("Blog/create")]
        public async Task<IActionResult> Create([FromBody] BlogVM blog)
        {
            var result = await _blogServices.CreateBlog(blog);
            return Ok(result);
        }

        [HttpPut("Blog/update/{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] BlogVM blog)
        {
            var result = await _blogServices.EditBlog(blog);

            return Ok(result);
        }

        [HttpGet("Blog/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var blog = await _blogServices.GetBlogById(id);
            return Ok(blog);
        }


        [HttpDelete("Blog/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _blogServices.DeleteBlog(id);
            return Ok(result);
        }
    }
}
