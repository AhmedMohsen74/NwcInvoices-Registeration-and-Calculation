using Microsoft.AspNetCore.Mvc;
using NWC_Water_Consumption_project.Models;

namespace NWC_Water_Consumption_project.Controllers
{
    public class RealEstateController : Controller
    {
        NwcWaterDbContext RealEstate = new NwcWaterDbContext();

        [HttpPost]
        public IActionResult UpdateRecord(IFormCollection nwcRrealEstateType)
        {
            string Code = nwcRrealEstateType["Code"];
            string Name = nwcRrealEstateType["Name"];
            string Reasons = nwcRrealEstateType["Reasons"];


            var model = new TblNwcRrealEstateType();

            var recordToUpdate = RealEstate.TblNwcRrealEstateTypes.FirstOrDefault(r => r.NwcRrealEstateTypesCode == Code);
            if (recordToUpdate == null)
            {
                TempData["Failed Message"] = "برجاء التأكد من رمز العقار";
                return View("RealEstate", model);
            }
            else
            {
                recordToUpdate.NwcRrealEstateTypesName = Name;
                recordToUpdate.NwcRrealEstateTypesReasons = Reasons;
                RealEstate.SaveChanges();
                TempData["SuccessMessage"] = "تم التحديث بنجاح";
                return View("RealEstate", model);
            }
        }

        public ActionResult UpdateView()
        {
            var model = new TblNwcRrealEstateType();
            return View("RealEstate", model);
        }
    }
}
