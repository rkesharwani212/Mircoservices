using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsersService.Model;

namespace UsersService.Services
{
    public class AccountService : IAccountService
    {
        private User userManager;
        private readonly IConfiguration _configuration;
        public AccountService(User user,IConfiguration configuration)
        {
            this.userManager = user;
            _configuration = configuration;
            userManager.signup.Add(new Signup
            {
                Id = 1,
                Email = "admin@gmail.com",
                FirstName = "admin",
                LastName = "admin",
                Role = "Admin",
                ConfirmPassword = "Admin1@123",
                Password = "Admin1@123"
            });
        }

        public User CreateUser(Signup signup)
        {
            var isExist = userManager.signup.Any(x => x.Email == signup.Email);
            if (isExist == true)
            {
                return new User { signin = null, signup = null,isSuccess = false, message ="" };

            }
            var user = new Signup
            {
                Id = userManager.signup.Count + 1,
                FirstName = signup.FirstName,
                LastName = signup.LastName,
                Email = signup.Email,
                Role = signup.Role,
                Password = signup.Password,
                ConfirmPassword = signup.ConfirmPassword
               
            };
            userManager.isSuccess = true;
            userManager.message = "Email Added Successfully";
            userManager.signup.Add(user);
            return userManager;
            
        }
        public async Task<string> LoginUser(Signin signin)
        {
            var result = userManager.signup.Any(x => x.Email == signin.Email && x.Password == signin.Password);
            if (!result)
            {
                return null;
            }
            var user = userManager.signup.FirstOrDefault(x => x.Email == signin.Email);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signin.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }

}
