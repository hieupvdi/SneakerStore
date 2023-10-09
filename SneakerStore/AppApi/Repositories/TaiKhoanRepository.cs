using AppApi.IRepositories;
using AppApi.SneakerDbContext;
using AppData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppApi.Repositories
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private SNDbcontext _dbcontext;


        public TaiKhoanRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<Guid>> roleManager, SNDbcontext dbcontext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public async Task<string> SignInAsync(SignInModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                // Đăng nhập thành công
                await _signInManager.SignInAsync(user, isPersistent: false);
                var token = await GenerateToken(user);
                return token;
            }

            // Đăng nhập thất bại
            return null; // Hoặc bạn có thể trả về một giá trị khác để chỉ ra đăng nhập thất bại
        }

        public async Task<string> GenerateToken(ApplicationUser model)
        {
            // Định nghĩa các claims cho token
            var claims = new[]
            {
              new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "exampleuser"),
                new Claim(ClaimTypes.Email, "example@example.com"),
                new Claim(ClaimTypes.Role, "Admin"),
                // Các claims khác có thể thêm vào ở đây
             };

            // Định nghĩa key 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JwtSettings:Key"));
            // Tạo credentials bằng cách sử dụng key và mã hóa HmacSha256
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.UtcNow.AddHours(60);

            // Tạo token JWT
            var token = new JwtSecurityToken(
                issuer: "JwtSettings:Issuer",
                audience: "JwtSettings:Audience",
                claims: claims,
                expires: expiry,
                signingCredentials: creds
            );

            // Trả về token dưới dạng chuỗi
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<List<ApplicationUser>> GetAllAsync()
        {
            return _dbcontext.AspNetUsers.ToList();
        }
    }
}
