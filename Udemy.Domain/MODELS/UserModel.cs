


using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.MODELS
{
    public class UserModel : IdentityUser
    {
   
        public string FirstName { get; set; }
        public string LastName { get; set; }
       public string Role {  get; set; }
    }
}