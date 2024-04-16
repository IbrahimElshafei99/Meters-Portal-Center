using MetersCenter.Core_.Contexts;
using MetersCenter.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Core_.Repos
{
    public class MeterDataRepo
    {
        private readonly ApplicationDbContext _context;
        public MeterDataRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MeterData> GetById(int id)
        {
            var result = await _context.MeterData.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<MeterData> UpdateMeter(int id, MeterData meter)
        {
            if(id==meter.Id)
            {
                var newMeter = await _context.MeterData.FirstOrDefaultAsync(x => x.Id == id);
                if (newMeter != null)
                {
                    newMeter.MeterPublicKey = meter.MeterPublicKey;
                    newMeter.MeterSerial = meter.MeterSerial;

                    _context.MeterData.Update(newMeter);
                    await _context.SaveChangesAsync();
                    return newMeter;
                }
            }
            return meter; //check this
        }

    }
}
