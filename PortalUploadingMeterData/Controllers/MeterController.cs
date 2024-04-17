using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using PortalUploadingMeterData.Models;
using System.Reflection.PortableExecutable;
using System.Text;

namespace PortalUploadingMeterData.Controllers
{
    //public class MeterController : Controller
    //{
        
    //    private readonly AppDbContext _context;

    //    public MeterController(AppDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public IActionResult UploadExcel()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> UploadExcel(IFormFile file)
    //    {
    //        var compName = Request.Form["LogOffTime"].ToString();
    //        var compId = _context.Company.Where(x => x.Name == compName).Select(x => x.Id).First();

    //        if (file != null && file.Length > 0)
    //        {
    //            MasterRecord masterRecord = new MasterRecord() { UploadDate = DateTime.Now };
    //            _context.MasterRecord.Add(masterRecord);
    //            _context.SaveChanges();

    //            using (var package = new ExcelPackage(file.OpenReadStream()))
    //            {
    //                var worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first sheet

    //                int rowCount = worksheet.Dimension.Rows;
    //                int batchSize = 1000; // Define batch size
    //                var batchSerials = new List<string>();

    //                for (int row = 2; row <= rowCount; row += batchSize)
    //                {
    //                    int endRow = Math.Min(row + batchSize - 1, rowCount);

    //                    // Process data in batches
    //                    var batchData = new List<MeterData>();

    //                    for (int currentRow = row; currentRow <= endRow; currentRow++)
    //                    {
    //                        // Validate records
    //                        if (batchSerials.Contains(worksheet.Cells[currentRow, 1].Value.ToString()))
    //                        {
    //                            continue;
    //                        }

    //                        // Extract data from Excel row and create MeterData objects
    //                        var Meter = new MeterData()
    //                        {
    //                            MeterSerial = worksheet.Cells[currentRow, 1].Value.ToString(),
    //                            MeterPublicKey = worksheet.Cells[currentRow, 2].Value.ToString(),
    //                            status = "New",
    //                            CompanyId = compId,
    //                            MasterRecordId = masterRecord.Id
    //                        };

    //                        batchSerials.Add(Meter.MeterSerial);
    //                        batchData.Add(Meter);
    //                    }

    //                    SaveBatchData(batchData);
    //                }
    //            }
    //            var allMetersInSheet = await _context.MeterData.Where(m => m.MasterRecordId == masterRecord.Id).ToListAsync();
    //            masterRecord.MeterData = allMetersInSheet;
    //            _context.MasterRecord.Attach(masterRecord);
    //            _context.SaveChanges();
    //        }
    //        return View();
    //    }

    //    private void SaveBatchData(List<MeterData> batch)
    //    {
    //        _context.MeterData.AddRange(batch);
    //        _context.SaveChanges();
    //    }



    //    public async Task<IActionResult> GetMetersById(int id)
    //    {
    //        TempData["recordId"] = id;
    //        var meters = await _context.MeterData.Include(c => c.Company).Where(x => x.MasterRecordId == id).ToListAsync();
    //        return View(meters);
    //    }

    //    public async Task<IActionResult> EditMeter(int id)
    //    {
    //        var meter = await _context.MeterData.Include(c => c.Company).FirstOrDefaultAsync(x => x.Id == id);
    //        if (meter == null)
    //        {
    //            return View("NotFound");
    //        }
    //        TempData["masterRecId"] = meter.MasterRecordId;
    //        return View(meter);
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> EditMeter(int id, MeterData meter)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var newMeter = await _context.MeterData.FirstOrDefaultAsync(x => x.Id == meter.Id);
    //            newMeter.MeterSerial = meter.MeterSerial;
    //            newMeter.MeterPublicKey = meter.MeterPublicKey;
    //            newMeter.status = meter.status;
    //            //newMeter.CompanyId = _context.Company.Where(x => x.Name == meter.Company.Name).Select(x => x.Id).First();

    //            _context.MeterData.Update(newMeter);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction("GetMetersById", new { id = newMeter.MasterRecordId });
    //        }
    //        return View(meter);
    //    }


    //}
}
