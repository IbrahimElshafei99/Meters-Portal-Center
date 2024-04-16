using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalUploadingMeterData.Models;

namespace WebAPIConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MeterController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> GetMeterInfo(int compId, string Serial)
        {
            var meter = await _context.MeterData.FirstOrDefaultAsync(m=> m.MeterSerial == Serial && m.CompanyId == compId);
            if(meter == null)
            {
                return BadRequest(string.Empty);
            }
            var meterDetails = (from M in _context.MeterData
                                join MR in _context.MasterRecord on M.MasterRecordId equals MR.Id
                                where M.Id == meter.Id
                                join C in _context.Company on M.CompanyId equals C.Id
                                select new
                                {
                                    RecordId = MR.Id,
                                    UploadRecordDate = MR.UploadDate,
                                    MeterSerialNumber = M.MeterSerial,
                                    PublicKey = M.MeterPublicKey,
                                    Status = M.status,
                                    CompanyName = C.Name
                                });
            return Ok(meterDetails);
        }
    }
}
