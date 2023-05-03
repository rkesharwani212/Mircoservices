using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersService.Model;
using UsersService.Services;

namespace UsersService.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("Signup")]
        public async Task<IActionResult> SignUp([FromBody] Signup signup)
        {
            var result = _accountService.CreateUser(signup);

            if (result.isSuccess)
            {
                return Ok(true);
            }

            return Unauthorized();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Signin signin)
        {
            //if(ModelState.IsValid)
            //{
            //    var result = await _accountService.LoginUser(signIn);
            //    if(result.Succeeded)
            //    {
            //        return Ok(result);
            //    }
            //}

            //return Unauthorized();
            var result = await _accountService.LoginUser(signin);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
