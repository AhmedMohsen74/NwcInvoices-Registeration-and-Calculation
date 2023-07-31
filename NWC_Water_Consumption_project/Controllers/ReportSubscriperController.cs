using Microsoft.AspNetCore.Mvc;
using NWC_Water_Consumption_project.Models;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

namespace NWC_Water_Consumption_project.Controllers
{
    public class ReportSubscriperController : Controller
    {
        NwcWaterDbContext context= new NwcWaterDbContext();
        public IActionResult Get_Report_Subscriber()
        {
            var SubScriper = context.TblNwcSubscriberFiles.ToList();
            var SubScription = context.TblNwcSubscriptionFiles.ToList();

            var ResultOfQuery = (from S1 in SubScriper
                                 join S2 in SubScription
                                 on S1.NwcSubscriberFileId
                                 equals S2.NwcSubscriptionFileSubscriberCode
                                 into S2Group
                                 from S2 in S2Group.DefaultIfEmpty()
                                 group S2 by new
                                 {
                                     S1.NwcSubscriberFileId,
                                     S1.NwcSubscriberFileName,
                                     S1.NwcSubscriberFileCity,
                                     S1.NwcSubscriberFileArea,
                                     S1.NwcSubscriberFileMobile
                                 } into Value
                                 select new TblNwcSubscriberFile
                                 {
                                     NwcSubscriberFileId = Value.Key.NwcSubscriberFileId,
                                     NwcSubscriberFileName = Value.Key.NwcSubscriberFileName,
                                     NwcSubscriberFileCity = Value.Key.NwcSubscriberFileCity,
                                     NwcSubscriberFileArea = Value.Key.NwcSubscriberFileArea,
                                     NwcSubscriberFileMobile = Value.Key.NwcSubscriberFileMobile,
                                     NumbOfsubsc = (Value.Count(v => v != null))
                                 }).Select((item, index) => new TblNwcSubscriberFile
                                 {
                                     NwcSubscriberFileId = item.NwcSubscriberFileId,
                                     NwcSubscriberFileName = item.NwcSubscriberFileName,
                                     NwcSubscriberFileCity = item.NwcSubscriberFileCity,
                                     NwcSubscriberFileArea = item.NwcSubscriberFileArea,
                                     NwcSubscriberFileMobile = item.NwcSubscriberFileMobile,
                                     NumbOfsubsc = item.NumbOfsubsc,
                                     Counter = index + 1
                                 }).ToList();    
            return View("ReportSubscriper",ResultOfQuery);
        }
    }
}
