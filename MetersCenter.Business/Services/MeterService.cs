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

        public IEnumerable<MeterData> GetMetersByRecordId(int id)
        {
            return _dataRepo.GetMetersByRecordId(id);
        }

        public async Task<IEnumerable<object>> GetMeterDetailsBySerial(string providerName ,string serial)
        {
            var supps = _suppliesRepo.GetSuppliesByProviderName(providerName);

            return await _dataRepo.GetMeterDetailsBySerial(supps, serial);
        }

        public async Task<MeterData> UpdateMeter(int id, MeterData meter)
        {
            return await _dataRepo.UpdateMeter(id, meter);
        }
    }
}
