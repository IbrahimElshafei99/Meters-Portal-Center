using ExcelDataReader;
using MetersCenter.Business.Interfaces;
using MetersCenter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using PortalUploadingMeterData.Models;
using System.Drawing.Printing;
using System.Reflection.PortableExecutable;
using System.Text;

namespace PortalUploadingMeterData.Controllers
{
    public class MeterController : Controller
    {
        private readonly IMeterService _meterService;
        public MeterController(IMeterService meterService)
        {
            _meterService = meterService;
        }
    
        private static IEnumerable<MeterData> listOfMeters = new List<MeterData>();
        public async Task<IActionResult> MetersList(int id, int? pageNumber)
        {
            int pageSize = 3;
            if (id == 0)
            {
                return View(PaginatedList<MeterData>.Create(listOfMeters.ToList(), pageNumber ?? 1, pageSize));
            }
            var meters = await _meterService.GetMetersByRecordId(id);
            if(meters == null)
            {
                return View("NotFound");
            }
            return View(PaginatedList<MeterData>.Create(meters.ToList(), pageNumber ?? 1, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> FilterMeters(string serial, int suppId)
        {
            listOfMeters = await _meterService.GetMetersBySerial(serial, suppId);
            return RedirectToAction("MetersList", new { id = 0 });
        }



    }
}
