using MetersCenter.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PortalUploadingMeterData.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly ISuppliesService _suppliesService;
        public SuppliesController(ISuppliesService suppliesService)
        {
            _suppliesService = suppliesService;
        }

        public IActionResult UploadExcel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            var compName = Request.Form["LogOffTime"].ToString();
            if (file == null || file.Length == 0)
            {
                return View("NotFound");
            }
            try
            {
                var uploadedMeters = await _suppliesService.UploadExcelSheet(file.OpenReadStream(), compName);
                TempData["SuccessMetersRows"] = uploadedMeters.Item1;
                return RedirectToAction("MetersList", "Meter", uploadedMeters.Item2.Where(x => true).Select(x => x.SuppliesId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error uploading file: {ex.Message}");
            }
        }

        public async Task<IActionResult> GetAllSupplies()
        {
            var supps = await _suppliesService.GetAllSupplies();
            return View(supps);
        }
        public async Task<IActionResult> SuppliesList(int id)
        {
            var supps = await _suppliesService.GetSuppliesByID(id);
            return View(supps);
        }
    }
}
