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
<<<<<<< HEAD
        Task<IEnumerable<MeterData>> GetMetersByRecordId(int id);
        Task<IEnumerable<MeterData>> GetMetersBySerial(string serial, int suppId);
=======
        IEnumerable<MeterData> GetMetersByRecordId(int id);
>>>>>>> 7c42d8df253d91854a6d3b0f9d4ec91eca4a23b3
        Task<IEnumerable<object>> GetMeterDetailsBySerial(string providerName, string serial);
        Task<MeterData> UpdateMeter(int id, MeterData meter);
    }
}
