using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetersCenter.Data;

namespace MetersCenter.Business.Interfaces
{
    public interface IMeterService
    {
        Task<IEnumerable<MeterData>> AddMetersRange(IEnumerable<MeterData> meters);
        Task<MeterData> GetById(int id);
        IEnumerable<MeterData> GetMetersByRecordId(int id);
        Task<IEnumerable<object>> GetMeterDetailsBySerial(string providerName, string serial);
        Task<MeterData> UpdateMeter(int id, MeterData meter);
    }
}
