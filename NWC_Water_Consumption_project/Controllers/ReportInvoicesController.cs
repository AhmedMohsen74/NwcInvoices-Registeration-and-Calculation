using Microsoft.AspNetCore.Mvc;
using NWC_Water_Consumption_project.Models;
using System.Runtime.Intrinsics.Arm;

namespace NWC_Water_Consumption_project.Controllers
{
    public class ReportInvoicesController : Controller
    {
        NwcWaterDbContext context = new NwcWaterDbContext();
        public IActionResult Get_Report_Invoices()
        {
            var invoices = context.TblNwcInvoices.ToList();
            var subscriber = context.TblNwcSubscriberFiles.ToList();
            var subscribtion = context.TblNwcSubscriptionFiles.ToList();

            DateTime now = DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;


            var ResultOfView = (from I1 in invoices
                                join S1 in subscriber on I1.NwcInvoicesSubscriberNo equals S1.NwcSubscriberFileId
                                join S2 in subscribtion on I1.NwcInvoicesSubscriptionNo equals S2.NwcSubscriptionFileNo
                                select new TblNwcInvoice
                                {
                                    NwcInvoicesNo = I1.NwcInvoicesNo,
                                    NwcInvoicesSubscriptionNo = I1.NwcInvoicesSubscriptionNo,
                                    NwcInvoicesSubscriberNo = I1.NwcInvoicesSubscriberNo,
                                    Name = S1.NwcSubscriberFileName,
                                    NwcInvoicesDate =  I1.NwcInvoicesDate,
                                    NwcInvoicesPreviousConsumptionAmount = I1.NwcInvoicesPreviousConsumptionAmount,
                                    NwcInvoicesCurrentConsumptionAmount = I1.NwcInvoicesCurrentConsumptionAmount,
                                    NwcInvoicesAmountConsumption = I1.NwcInvoicesAmountConsumption,
                                    NwcInvoicesTotalInvoice = I1.NwcInvoicesTotalInvoice,
                                    NwcInvoicesTotalBill = I1.NwcInvoicesTotalBill
                                }).Select((item, Index) => new TblNwcInvoice
                                {
                                    NwcInvoicesNo = item.NwcInvoicesNo,
                                    NwcInvoicesSubscriptionNo = item.NwcInvoicesSubscriptionNo,
                                    NwcInvoicesSubscriberNo = item.NwcInvoicesSubscriberNo,
                                    Name = item.Name,

                                    day = (item.NwcInvoicesDate).Value.Day,
                                    month = (item.NwcInvoicesDate).Value.Month,
                                    year = (item.NwcInvoicesDate).Value.Year,
                                    dateto = $"{day}-{month}-{year}",

                                    NwcInvoicesPreviousConsumptionAmount = item.NwcInvoicesPreviousConsumptionAmount,
                                    NwcInvoicesCurrentConsumptionAmount = item.NwcInvoicesCurrentConsumptionAmount,
                                    NwcInvoicesAmountConsumption = item.NwcInvoicesAmountConsumption,
                                    NwcInvoicesTotalInvoice = item.NwcInvoicesTotalInvoice,
                                    NwcInvoicesTotalBill = item.NwcInvoicesTotalBill,
                                    Counter = Index + 1
                                }).ToList();
            return View("ReportInvoices",ResultOfView);
        }
    }
}
