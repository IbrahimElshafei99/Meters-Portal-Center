﻿using MetersCenter.Business.Interfaces;
using MetersCenter.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public async Task<IActionResult> GetAllSupplies(int? pageNumber)
        {
            int pageSize = 3;
            if(ListOfSupplies.Any())
            {
                return View(PaginatedList<Supplies>.Create(ListOfSupplies.ToList(), pageNumber ?? 1, pageSize));
            }
            var supps = await _suppliesService.GetAllSupplies();
            return View(PaginatedList<Supplies>.Create(supps.ToList(), pageNumber?? 1, pageSize));
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
            
            if(ListOfSupplies.Count()==1)
                TempData["providerName"]= await _suppliesService.GetProviderNameBySupplyId(supplyId);
            
            return RedirectToAction("GetAllSupplies", "Supplies");
        }

        public async Task<IActionResult> EditSupply(int id)
        {
            var supply = await _suppliesService.GetSupplyID(id);
            return View(supply);
        }

        [HttpPost]
        [RequestSizeLimit(10000000)]
        public async Task<IActionResult> EditSupply([Bind("Id,status")]Supplies supply, IFormFile docFile)
        {
            if(docFile!=null)
            {
                var permittedExtensions = new[] { ".docx" };
                var extension = Path.GetExtension(docFile.FileName).ToLowerInvariant();
                if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("", "Invalid file type.");
                }
            }
            
            if (ModelState.IsValid)
            {
                await _suppliesService.EditSupply(supply, docFile);
                return RedirectToAction("GetAllSupplies");
            }
            return View(supply);
        }
    }
}
