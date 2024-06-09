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
    public class MeterDataRepo : IMeterDataRepo
    {
        private readonly ApplicationDbContext _context;
        public MeterDataRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MeterData>> AddMetersRange(IEnumerable<MeterData> meters)
        {
            await _context.MeterData.AddRangeAsync(meters);
            _context.SaveChanges();
            return meters;
        }

        public async Task<MeterData> GetById(int id)
        {
            var result = await _context.MeterData.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

<<<<<<< HEAD
        public async Task<IEnumerable<MeterData>> GetMetersByRecordId(int id)
=======
        public IEnumerable<MeterData> GetMetersByRecordId(int id)
>>>>>>> 7c42d8df253d91854a6d3b0f9d4ec91eca4a23b3
        {
            var meters = await _context.MeterData.Where(x => x.SuppliesId == id).ToListAsync();
            return meters;
        }

<<<<<<< HEAD
        public async Task<IEnumerable<MeterData>> GetMetersBySerial(string serial, int suppId)
        {
            var meters = await _context.MeterData.Where(x=>x.MeterSerial == serial && x.SuppliesId==suppId).ToListAsync();
            return meters;
        }

        public async Task<List<object>> GetMeterDetailsBySerial(IEnumerable<Supplies>supplies, string serial)
        {
=======
        public async Task<List<object>> GetMeterDetailsBySerial(IEnumerable<Supplies>supplies, string serial)
        {
>>>>>>> 7c42d8df253d91854a6d3b0f9d4ec91eca4a23b3
            List<object> meterDetails = new List<object>();
            foreach(var s in supplies)
            {
                var meter = await _context.MeterData.FirstOrDefaultAsync(x=>x.SuppliesId==s.Id && x.MeterSerial==serial);
                if (meter != null)
                {
                    var compName = _context.MeterProviders.Where(x => x.Id == s.MeterProviderId).Select(x => x.Name).First();

                    meterDetails.Add(meter.MeterPublicKey);
                    meterDetails.Add(meter.MeterSerial);
                    meterDetails.Add(compName);
                    meterDetails.Add(s.status);
                    meterDetails.Add(s.UploadDate);
                    meterDetails.Add(s.UploadUsername);

                    return meterDetails;
                }
            }
            return meterDetails;
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
