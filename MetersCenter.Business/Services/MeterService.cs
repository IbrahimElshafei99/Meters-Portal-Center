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
        public MeterService(IMeterDataRepo dataRepo)
        {
            _dataRepo = dataRepo;
        }

        public async Task<IEnumerable<MeterData>> AddMetersRange(IEnumerable<MeterData> meters)
        {
            return await _dataRepo.AddMetersRange(meters);
        }

        public async Task<MeterData> GetById(int id)
        {
            return await _dataRepo.GetById(id);
        }

        public List<MeterData> GetMetersByRecordId(int id)
        {
            return _dataRepo.GetMetersByRecordId(id);
        }

        public async Task<IEnumerable<MeterData>> GetMetersBySerial(string serial)
        {
            return await _dataRepo.GetMetersBySerial(serial);
        }

        public async Task<MeterData> UpdateMeter(int id, MeterData meter)
        {
            return await _dataRepo.UpdateMeter(id, meter);
        }
    }
}
