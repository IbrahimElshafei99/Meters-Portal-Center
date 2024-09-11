using MetersCenter.Core_.Contexts;
using MetersCenter.Core_.Interfaces;
using MetersCenter.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Core_.Repos
{
    public class MeterProviderRepo : IMeterProviderRepo
    {
        private readonly ApplicationDbContext _context;
        public MeterProviderRepo (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetProviderNameById(int id)
        {
            return await _context.MeterProviders.Where(x => x.Id == id).Select(x => x.Name).FirstAsync();
            
        }

        public async Task<string> GetProviderNameBySupplyId(int id)
        {
            var supply = await _context.Supplies.FirstAsync(x=>x.Id==id);
            return await _context.MeterProviders.Where(x => x.Id == supply.MeterProviderId).Select(x => x.Name).FirstAsync();

        }

        public async Task<int> GetProviderIdByName(string name)
        {
            return await _context.MeterProviders.Where(x => x.Name == name).Select(x => x.Id).FirstAsync();

        }
    }
}
