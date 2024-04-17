using MetersCenter.Business.Interfaces;
using MetersCenter.Data;
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
                return RedirectToAction("MetersList", "Meter", new { id = uploadedMeters.Item2 });
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error uploading file: {ex.Message}");
            }
        }

        private static IEnumerable<Supplies> ListOfSupplies = new List<Supplies>();
        public async Task<IActionResult> GetAllSupplies()
        {
            if(ListOfSupplies.Any())
            {
                return View(ListOfSupplies);
            }
            var supps = await _suppliesService.GetAllSupplies();
            return View(supps);
        }
        //public async Task<IActionResult> SuppliesList(int id)
        //{
        //    var supps = await _suppliesService.GetSuppliesByID(id);
        //    return View(supps);
        //}

        [HttpPost]
        public async Task<IActionResult> FilterSupplies(string providerName, int supplyId)
        {
            ListOfSupplies = await _suppliesService.GetSuppliesByIdAndProviderName(providerName, supplyId);
            return RedirectToAction("GetAllSupplies", "Supplies");
        }

        public async Task<IActionResult> EditSupply(int id)
        {
            var supply = await _suppliesService.GetSupplyID(id);
            return View(supply);
        }

        [HttpPost]
        public async Task<IActionResult> EditSupply([Bind("Id,status")]Supplies supply)
        {
            if(ModelState.IsValid)
            {
                await _suppliesService.EditSupply(supply);
                return RedirectToAction("GetAllSupplies");
            }
            return View(supply);
        }
    }
}
