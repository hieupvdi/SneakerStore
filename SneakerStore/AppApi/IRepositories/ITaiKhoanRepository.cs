using AppData.Models;
using Microsoft.AspNetCore.Identity;

namespace AppApi.IRepositories
{
    public interface ITaiKhoanRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);

        public Task<string> GenerateToken(ApplicationUser model);
        public Task<List<ApplicationUser>> GetAllAsync();
    }
}
