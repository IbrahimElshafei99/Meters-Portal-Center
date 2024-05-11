using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetersCenter.Data;

namespace MetersCenter.Core_.Interfaces
{
    public interface IMeterDataRepo
    {
        Task<IEnumerable<MeterData>> AddMetersRange(IEnumerable<MeterData> meters);
        Task<MeterData> GetById(int id);
<<<<<<< HEAD
        Task<IEnumerable<MeterData>> GetMetersByRecordId(int id);
        Task<IEnumerable<MeterData>> GetMetersBySerial(string serial, int suppId);
=======
        IEnumerable<MeterData> GetMetersByRecordId(int id);
>>>>>>> 7c42d8df253d91854a6d3b0f9d4ec91eca4a23b3
        Task<List<object>> GetMeterDetailsBySerial(IEnumerable<Supplies> supplies, string serial);
        Task<MeterData> UpdateMeter(int id, MeterData meter);

    }
}
