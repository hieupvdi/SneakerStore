using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IBlogServices
    {
        public Task<List<BlogVM>> GetBlogAll();
        public Task<bool> CreateBlog(BlogVM obj);
        public Task<bool> EditBlog(BlogVM obj);
        public Task<bool> DeleteBlog(Guid id);
        public Task<BlogVM> GetBlogById(Guid id);
    }
}
