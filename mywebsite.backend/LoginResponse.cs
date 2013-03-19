using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mywebsite.backend
{
    public class LoginResponse
    {
        public bool NewProfileCreated { get; set; }

        public Profile Profile { get; set; }
    }
}
