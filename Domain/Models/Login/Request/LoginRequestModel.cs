using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Login.Request
{
    public class LoginRequestModel
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
