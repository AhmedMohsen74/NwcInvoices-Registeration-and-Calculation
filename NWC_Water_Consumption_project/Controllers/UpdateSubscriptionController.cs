using Microsoft.AspNetCore.Mvc;
using NWC_Water_Consumption_project.Models;

namespace NWC_Water_Consumption_project.Controllers
{
    public class UpdateSubscriptionController : Controller
    {
        NwcWaterDbContext context = new NwcWaterDbContext();

        [HttpPost]

        public JsonResult DoUpdateSubscribtion(String subscriptionId)
        {
            var SearchRecordQuery = context.TblNwcSubscriberFiles.FirstOrDefault(r => r.NwcSubscriberFileId == subscriptionId);


            if (SearchRecordQuery == null)
            {
                TempData["Failed Message"] = "تأكد من رقم الهوية";
                return Json(subscriptionId);
            }
            else
            {
                string SubscriberName = SearchRecordQuery.NwcSubscriberFileName.ToString();
                string SubscriberCity = SearchRecordQuery.NwcSubscriberFileCity.ToString();
                string SubscriberArea = SearchRecordQuery.NwcSubscriberFileArea.ToString();
                string SubscriberMobile = SearchRecordQuery.NwcSubscriberFileMobile.ToString();


                return Json(new
                {
                    da1 = SubscriberName,
                    da2 = SubscriberCity,
                    da3 = SubscriberArea,
                    da4 = SubscriberMobile
                });
            }
        }
        [HttpPost]
        public IActionResult Save(IFormCollection GetForm)
        {
            if (Request.Form["SubscribtionNo"].ToString() != "" && Request.Form["SubscribtionNo"].ToString() != "" && Request.Form["SubSubCode"].ToString() != "" && Request.Form["Unit"].ToString() != "")
            {


                bool Ychecked = GetForm["Yes"] == "true";
                bool NChecked = GetForm["No"] == "false";
                bool Subscription_File_Is_There_Sanitation = true;

                if (NChecked)
                {
                    Subscription_File_Is_There_Sanitation = false;
                }


                string Type_Of_realestate = GetForm["Type"];
                string Subscribtion_No = Request.Form["SubscribtionNo"];
                string Subscription_File_Subscriber_Code = Request.Form["SubSubCode"];
                decimal Unit = decimal.Parse(Request.Form["Unit"]);


                TblNwcSubscriptionFile SubscriptionFile = new TblNwcSubscriptionFile
                {
                    NwcSubscriptionFileNo = Subscribtion_No,
                    NwcSubscriptionFileSubscriberCode = Subscription_File_Subscriber_Code,
                    NwcSubscriptionFileRrealEstateTypesCode = Type_Of_realestate,
                    NwcSubscriptionFileUnitNo = Unit,
                    NwcSubscriptionFileIsThereSanitation = Subscription_File_Is_There_Sanitation
                };

                context.TblNwcSubscriptionFiles.Add(SubscriptionFile);
                context.SaveChanges();
                TempData["SuccessMessage"] = "!تم التحديث بنجاح";
            }
            else
            {
                TempData["ErrorMessage"] = ".خطأ.. اعد المحاولة وتأكد من تعبئة البيانات";
            }
            return RedirectToAction("CreateView");

        }

        public IActionResult CreateView()
        {
            var m = new TblNwcSubscriptionFile();

            while (true)
            {
                //Ex: 23 - 1 - 119
                
                DateTime TimeNow = DateTime.Now;
                int Month = TimeNow.Month;
                int Year = TimeNow.Year;
                string lastTwoDigitsFormYear=(Year % 100).ToString("00");

                Random random = new Random();
                int RandomNumber = random.Next(1, 250);

                string generatedNumb = $"{lastTwoDigitsFormYear}-{Month}-{RandomNumber}"; 

                var SubscribtionIdQuery = context.TblNwcSubscriptionFiles.FirstOrDefault(r => r.NwcSubscriptionFileNo == generatedNumb);

                if (SubscribtionIdQuery != null)
                {
                    continue;
                }
                else
                {
                    m.NwcSubscriptionFileNo = generatedNumb;
                    break;
                }
            }
            return View("UpdateSubscription",m);  
        }
    }
}
