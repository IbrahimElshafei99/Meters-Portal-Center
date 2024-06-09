using MetersCenter.Business.Interfaces;
using MetersCenter.Core_.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetersCenter.Data;

namespace MetersCenter.Business.Services
{
    public class MeterService : IMeterService
    {
        private readonly IMeterDataRepo _dataRepo;
        private readonly ISuppliesRepo _suppliesRepo;
        public MeterService(IMeterDataRepo dataRepo, ISuppliesRepo suppliesRepo)
        {
            _dataRepo = dataRepo;
            _suppliesRepo = suppliesRepo;
        }

        public async Task<IEnumerable<MeterData>> AddMetersRange(IEnumerable<MeterData> meters)
        {
            return await _dataRepo.AddMetersRange(meters);
        }

        public async Task<MeterData> GetById(int id)
        {
            return await _dataRepo.GetById(id);
        }

<<<<<<< HEAD
        public async Task<IEnumerable<MeterData>> GetMetersByRecordId(int id)
=======
        public IEnumerable<MeterData> GetMetersByRecordId(int id)
>>>>>>> 7c42d8df253d91854a6d3b0f9d4ec91eca4a23b3
        {
            return await _dataRepo.GetMetersByRecordId(id);
        }

<<<<<<< HEAD
        public async Task<IEnumerable<MeterData>> GetMetersBySerial(string serial, int suppId)
        {
            return await _dataRepo.GetMetersBySerial(serial, suppId);
        }

        public async Task<IEnumerable<object>> GetMeterDetailsBySerial(string providerName ,string serial)
        {
=======
        public async Task<IEnumerable<object>> GetMeterDetailsBySerial(string providerName ,string serial)
        {
>>>>>>> 7c42d8df253d91854a6d3b0f9d4ec91eca4a23b3
            var supps = _suppliesRepo.GetSuppliesByProviderName(providerName);

            return await _dataRepo.GetMeterDetailsBySerial(supps, serial);
        }

        public async Task<MeterData> UpdateMeter(int id, MeterData meter)
        {
            return await _dataRepo.UpdateMeter(id, meter);
        }
    }
}
