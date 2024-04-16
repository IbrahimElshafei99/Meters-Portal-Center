﻿using MetersCenter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Business.Interfaces
{
    public interface ISuppliesService
    {
        void UploadExcelSheet(Stream excelFileStream);
        Task<Supplies> AddSupply(Supplies supply);
        Task<Supplies> AttachSupply(Supplies supply);
        Task<IEnumerable<Supplies>> GetAllSupplies();
        Task<Supplies> EditSupply(Supplies supply);
        Task<IEnumerable<Supplies>> GetSuppliesByID(int id);
        Task<IEnumerable<Supplies>> GetSuppliesByProviderName(string name);
        Task<IEnumerable<Supplies>> GetSuppliesByIdAndProviderName(string name, int id);

    }
}