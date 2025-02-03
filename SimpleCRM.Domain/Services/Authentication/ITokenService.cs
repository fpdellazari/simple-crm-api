using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Services.Authentication {
    public interface ITokenService {

        string Generate(string userName);
    }
}
