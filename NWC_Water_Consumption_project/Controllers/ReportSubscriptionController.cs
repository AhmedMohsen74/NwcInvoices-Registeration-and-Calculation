using Microsoft.AspNetCore.Mvc;
using NWC_Water_Consumption_project.Models;

namespace NWC_Water_Consumption_project.Controllers
{
    public class ReportSubscriptionController : Controller
    {
        NwcWaterDbContext context = new NwcWaterDbContext();
        public IActionResult Get_Report_Subscribtion()
        {
            var SubScriper = context.TblNwcSubscriberFiles.ToList();
            var SubScription = context.TblNwcSubscriptionFiles.ToList();
            var RealEstate = context.TblNwcRrealEstateTypes.ToList();
            var ResultOfQuery = (from S1 in SubScription
                                 join S2 in SubScriper on S1.NwcSubscriptionFileSubscriberCode equals S2.NwcSubscriberFileId into t2Group
                                 from S2 in t2Group.DefaultIfEmpty()
                                 join R3 in RealEstate on S1.NwcSubscriptionFileRrealEstateTypesCode equals R3.NwcRrealEstateTypesCode into t3Group
                                 from R3 in t3Group.DefaultIfEmpty()
                                 select new TblNwcSubscriptionFile
                                 {
                                     NwcSubscriptionFileNo = S1.NwcSubscriptionFileNo,
                                     NwcSubscriptionFileSubscriberCode = S1.NwcSubscriptionFileSubscriberCode,
                                     Name = S2.NwcSubscriberFileName,
                                     PhoneNumber = S2.NwcSubscriberFileMobile,
                                     Real_Estate_Type = R3.NwcRrealEstateTypesName,
                                     NwcSubscriptionFileUnitNo = S1.NwcSubscriptionFileUnitNo,
                                     Yes_or_No = S1.NwcSubscriptionFileIsThereSanitation != true ? "لا" : "نعم",
                                     NwcSubscriptionFileLastReadingMeter = S1.NwcSubscriptionFileLastReadingMeter,
                                     NwcSubscriptionFileReasons = S1.NwcSubscriptionFileReasons
                                 }).Select((item, index) => new TblNwcSubscriptionFile
                                 {
                                     NwcSubscriptionFileNo = item.NwcSubscriptionFileNo,
                                     NwcSubscriptionFileSubscriberCode = item.NwcSubscriptionFileSubscriberCode,
                                     Name = item.Name,
                                     PhoneNumber = item.PhoneNumber,
                                     Real_Estate_Type = item.Real_Estate_Type,
                                     NwcSubscriptionFileUnitNo = item.NwcSubscriptionFileUnitNo,
                                     Yes_or_No = item.Yes_or_No,
                                     NwcSubscriptionFileLastReadingMeter = item.NwcSubscriptionFileLastReadingMeter,
                                     NwcSubscriptionFileReasons = item.NwcSubscriptionFileReasons,
                                     Counter = index + 1
                                 }).ToList();
            return View("ReportSubscription", ResultOfQuery);
        }
    }
}
