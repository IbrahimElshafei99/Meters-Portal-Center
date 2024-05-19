using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Business.Interfaces
{
    public interface IAuthService
    {
        Task<string> GetToken(string username, string password);
    }
}
