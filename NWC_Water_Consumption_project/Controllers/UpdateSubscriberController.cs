using Microsoft.AspNetCore.Mvc;
using NWC_Water_Consumption_project.Models;

namespace NWC_Water_Consumption_project.Controllers
{
    public class UpdateSubscriberController : Controller
    {
        NwcWaterDbContext context = new NwcWaterDbContext();

        [HttpPost]

        public JsonResult GetData(String subscriberId)
        {
            var SearchRecordQuery = context.TblNwcSubscriberFiles.FirstOrDefault(r => r.NwcSubscriberFileId == subscriberId);


            if (SearchRecordQuery == null)
            {
                TempData["Failed Message"] = " ..خطأ..تأكد من رقم الهوية وقم بتعبئة البيانات بشكل صحيح ";
                return Json(subscriberId);
            }
            else
            {
                string SubscriberName = SearchRecordQuery.NwcSubscriberFileName.ToString();
                string SubscriberCity = SearchRecordQuery.NwcSubscriberFileCity.ToString();
                string SubscriberArea = SearchRecordQuery.NwcSubscriberFileArea.ToString();
                string SubscriberMobile = SearchRecordQuery.NwcSubscriberFileMobile.ToString();


                return Json(new
                {
                    d1 = SubscriberName,
                    d2 = SubscriberCity,
                    d3 = SubscriberArea,
                    d4 = SubscriberMobile
                });
            }
        }
        [HttpPost]

        public IActionResult Save(IFormCollection SubscriberFile)
        {
            var m = new TblNwcSubscriberFile();

            string NwcSubscriberFileCode = Request.Form["Code"];
            string NwcSubscriberFileName = SubscriberFile["Name"];
            string NwcSubscriberFilecity = SubscriberFile["City"];
            string NwcSubscriberFilearea = SubscriberFile["Area"];
            string NwcSubscriberFilephone = SubscriberFile["PhoneNumber"];

            var UpdatedRecord = context.TblNwcSubscriberFiles.FirstOrDefault(r => r.NwcSubscriberFileId == NwcSubscriberFileCode);

            if (UpdatedRecord == null)
            {
                TempData["Failed Message"] = " ..خطأ..تأكد من رقم الهوية وقم بتعبئة البيانات بشكل صحيح ";
                return View("UpdateSubscriber");
            }
            else
            {
                UpdatedRecord.NwcSubscriberFileId = NwcSubscriberFileCode;
                UpdatedRecord.NwcSubscriberFileName = NwcSubscriberFileName;
                UpdatedRecord.NwcSubscriberFileCity = NwcSubscriberFilecity;
                UpdatedRecord.NwcSubscriberFileArea = NwcSubscriberFilearea;
                UpdatedRecord.NwcSubscriberFileMobile = NwcSubscriberFilephone;
                context.SaveChanges();
                TempData["SuccessMessage"] = "تم التحديث بنجاح";

                return View("UpdateSubscriber", m);
            }
        }
        public ActionResult CreateView()
        {
            var model = new TblNwcSubscriberFile();
            return View("UpdateSubscriber", model);
        }
    }
}
