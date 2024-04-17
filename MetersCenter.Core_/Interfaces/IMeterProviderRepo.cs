using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Core_.Interfaces
{
    public interface IMeterProviderRepo
    {
        Task<string> GetProviderNameById(int id);
        Task<int> GetProviderIdByName(string name);
    }
}
