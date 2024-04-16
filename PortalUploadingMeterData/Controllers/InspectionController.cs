using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalUploadingMeterData.Models;
using System.Diagnostics.Metrics;

namespace PortalUploadingMeterData.Controllers
{
    public class InspectionController : Controller
    {
        private readonly AppDbContext _context;

        public InspectionController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Inspect(int meterId)
        {
            var InspectedMeter = await _context.Inspection.FirstOrDefaultAsync(x=>x.MeterId == meterId);
            if(InspectedMeter == null)
            {
                Inspection meterInspection = new Inspection()
                {
                    MeterId = meterId,
                    StratDate = DateTime.Now
                };
                _context.Inspection.Add(meterInspection);
                await _context.SaveChangesAsync();
                return View(meterInspection);
            }
            return View(InspectedMeter);
        }

        [HttpPost]
        public async Task<IActionResult> Inspect(int id, Inspection inspectionOfMeter)
        {
            var InsMeter = await _context.Inspection.FirstOrDefaultAsync(x => x.Id == inspectionOfMeter.Id);
            if (InsMeter == null)
            {
                return View("NotFound");
            }
            var meter = await _context.MeterData.FirstOrDefaultAsync(x => x.Id == InsMeter.MeterId);

            InsMeter.UserName = inspectionOfMeter.UserName;
            if(inspectionOfMeter.EndDate != default(DateTime))
            {
                InsMeter.EndDate = inspectionOfMeter.EndDate;
                meter.status = "Done";
                _context.MeterData.Update(meter);
            }
            else
            {
                meter.status = "In Progress";
                _context.MeterData.Update(meter);
            }

            _context.Inspection.Update(InsMeter);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetMetersById", "Meter", new {id = meter.MasterRecordId});
        }
    }
}
