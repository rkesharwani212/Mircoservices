using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersService.Model;

namespace UsersService.Services
{
    public interface IAccountService
    {
        User CreateUser(Signup signup);
        Task<string> LoginUser(Signin signin);
    }
}
