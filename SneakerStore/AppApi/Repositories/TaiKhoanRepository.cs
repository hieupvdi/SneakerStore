using AppApi.IRepositories;
using AppApi.SneakerDbContext;
using AppData.Models;
using Microsoft.AspNetCore.Identity;

namespace AppApi.Repositories
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private SNDbcontext _dbcontext;
     

        public TaiKhoanRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager,SNDbcontext dbcontext)                                 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbcontext = dbcontext;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                FullName = model.Email,
                DiaChi = model.Address,
                PhoneNumber = model.PhoneNumber,
                TrangThai = model.Status,
                UrlAnh = model.ImageUrl,
                PasswordHash = model.Password,
                UserName = model.UserName,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var us = await GetAllAsync();
                if (us.Count == 1) // nếu có 1 tài khoản ( trường hợp lần đầu tiên tạo tk )
                {
                    if (await _roleManager.RoleExistsAsync("Admin") == false)
                    {
                        await _roleManager.CreateAsync(new IdentityRole<Guid>("Admin")); // tạo role admin nếu chưa có
                    }

                    await _userManager.AddToRoleAsync(user, "Admin"); // gán role admin cho user đầu tiên đó
                }
                else
                {
                    // nếu khi tạo mới chưa có role là staff thì sẽ tạo mới 1 role là staff
                    if (await _roleManager.RoleExistsAsync("Staff") == false)
                    {
                        await _roleManager.CreateAsync(new IdentityRole<Guid>("Staff"));
                    }

                    // gán user với role là staff
                    await _userManager.AddToRoleAsync(user, "Staff");
                }
            }
            return result;
        }

        public Task<string> SignInAsync(SignInModel model)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateToken(ApplicationUser model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicationUser>> GetAllAsync()
        {
            return _dbcontext.AspNetUsers.ToList();
        }
    }
}
