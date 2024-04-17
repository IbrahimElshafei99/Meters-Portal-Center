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
        IEnumerable<MeterData> GetMetersByRecordId(int id);
        Task<List<object>> GetMeterDetailsBySerial(IEnumerable<Supplies> supplies, string serial);
        Task<MeterData> UpdateMeter(int id, MeterData meter);

    }
}
