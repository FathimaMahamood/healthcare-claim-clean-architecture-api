using HealthcareClaim.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtService _jwtService;
        public AuthController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(
        string username, string password, string role)
        {
            var user = new ApplicationUser
            {
                UserName = username
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, role);

            return Ok("User created");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
        string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                throw new Exception("User not found");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, password, false);

            if (!result.Succeeded)
                throw new Exception("Invalid credentials");

            var roles = await _userManager.GetRolesAsync(user);

            var accessToken = _jwtService.GenerateToken(user.Id, roles.First());

            var refreshToken = TokenHelper.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(user);

            return Ok(new
            {
                accessToken,
                refreshToken
            });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(string refreshToken)
        {
            var user = _userManager.Users
                .FirstOrDefault(u => u.RefreshToken == refreshToken);

            if (user == null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
                throw new Exception("Invalid or expired refresh token");

            var roles = await _userManager.GetRolesAsync(user);

            var newAccessToken = _jwtService.GenerateToken(user.Id, roles.First());

            var newRefreshToken = TokenHelper.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(user);

            return Ok(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken
            });
        }
    }
}
