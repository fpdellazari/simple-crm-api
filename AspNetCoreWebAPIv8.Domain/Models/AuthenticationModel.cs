using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreWebAPIv8.Domain.Models {
    public class AuthenticationModel {
        public required string Username { get; set; }
        public required string Password { get; set; }

    }
}
