using AspNetCoreWebAPIv8.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreWebAPIv8.Domain.Services {
    public interface IAuthenticationService {
        Task<string> Authenticate(AuthenticationModel authentication);
    }
}
