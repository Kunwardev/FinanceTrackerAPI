using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinanceTrackerAPI.Data;
using FinanceTrackerAPI.DTO;
using FinanceTrackerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FinanceTrackerAPI.Service;

public class UserService : IUserService
{
    private readonly FinanceContext _context;
    private readonly IConfiguration _config;
    private readonly IPasswordHasher<User> _hasher;

    public UserService(FinanceContext context, IConfiguration config){
        _context = context;
        _config = config;
        _hasher = new PasswordHasher<User>();
    }

    public async Task<string?> loginAsync(UserDTO userDTO)
    {
        var user = await _context.users.SingleOrDefaultAsync(u => u.name == userDTO.name);
        if(user == null)
            return null;
        var result = _hasher.VerifyHashedPassword(user, user.hashPassword, userDTO.hashPassword);
        if(result != PasswordVerificationResult.Success)
            return null;
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.name)
        };
         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<bool> registerUserAsync(UserDTO userDTO)
    {
        if (await _context.users.AnyAsync(u => u.name == userDTO.name))
            return false;

        var user = new User { name = userDTO.name };
        user.hashPassword = _hasher.HashPassword(user, userDTO.hashPassword);
        _context.users.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }
}