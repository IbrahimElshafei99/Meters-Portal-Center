using MetersCenter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Core_.Interfaces
{
    public interface ISuppliesRepo
    {
        Task<Supplies> AddSupply(Supplies supply);
        Task<Supplies> AttachSupply(Supplies supply);
        Task<IEnumerable<Supplies>> GetAllSupplies();
        Task<Supplies> EditSupply(Supplies supply);
<<<<<<< HEAD
        Task<Supplies> GetSupplyID(int id);
=======
        Task<IEnumerable<Supplies>> GetSuppliesByID(int id);
>>>>>>> 7c42d8df253d91854a6d3b0f9d4ec91eca4a23b3
        IEnumerable<Supplies> GetSuppliesByProviderName(string name);
        Task<IEnumerable<Supplies>> GetSuppliesByIdAndProviderName(string name, int id);
    }
}
