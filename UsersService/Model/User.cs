using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersService.Model
{
    public class User
    {
        public Signin? signin { get; set; }
        public IList<Signup?> signup { get; set; }=  new List<Signup?>();
        public Boolean isSuccess { get; set; }
        public string message { get; set; }

        //public User(Boolean isSuccess, string message)
        //{
        //    signup = new List<Signup>();
        //    this.isSuccess = isSuccess;
        //    this.message = message;

        //}
    }
}
