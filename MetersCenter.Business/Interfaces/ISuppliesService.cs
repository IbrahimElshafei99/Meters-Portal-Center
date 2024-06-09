using MetersCenter.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Business.Interfaces
{
    public interface ISuppliesService
    {
        Task<(int, int)> UploadExcelSheet(Stream excelFileStream, string providerName, string username, string userId);

        Task<(int, IEnumerable<MeterData>)> UploadExcelSheet(Stream excelFileStream, string providerName);

        Task<Supplies> AddSupply(Supplies supply);
        Task<Supplies> AttachSupply(Supplies supply);
        Task<IEnumerable<Supplies>> GetAllSupplies();
        Task<Supplies> EditSupply(Supplies supply, IFormFile docFile);
        Task<Supplies> GetSupplyID(int id);

        Task<IEnumerable<Supplies>> GetSuppliesByID(int id);
        IEnumerable<Supplies> GetSuppliesByProviderName(string name);
        Task<IEnumerable<Supplies>> GetSuppliesByIdAndProviderName(string name, int id);
        Task<string> GetProviderNameBySupplyId(int id);
    }
}
